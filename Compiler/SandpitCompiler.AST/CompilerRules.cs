using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST;

public static class CompilerRules {
    public static string? OnlyOneMainRule(IASTNode[] nodes, IScope currentScope) {
        var node = nodes.Last();

        return node is FileNode { MainNode.Length: > 1 } ? "more than one main" : null;
    }

    public static string? ExpressionTypeIsBooleanRule(IASTNode[] nodes, IScope currentScope) {
        var node = nodes.Last();

        if (node is WhileStatementNode wn) {
            return wn.Condition switch {
                // TODO rework to 'resolve' the type of the expression
                ScalarValueNode { SymbolType: BuiltInType { Name : "Bool" } } => null,
                BinaryExpressionNode { Op.Operator: Constants.Operators.Eq or Constants.Operators.Ne } => null,
                _ => "control expression must be bool"
            };
        }

        return null;
    }

    public static string? NoProcedureInFunctionRule(IASTNode[] nodes, IScope currentScope) {
        var leafNode = nodes.Last();

        if (leafNode is MethodStatementNode msn) {
            if (currentScope.Resolve(msn.ID.Text) is MethodSymbol { MethodType: MethodType.Procedure or MethodType.SystemCall }) {
                if (nodes.Any(n => n is FunctionDefinitionNode)) {
                    return "Cannot have procedure/system call in function";
                }
            }
        }

        return null;
    }

    // TODO this is a hack - really need to understand better the semantics - may require refining the AST
    public static string? ExpressionMustBeAssignedRule(IASTNode[] nodes, IScope currentScope) {
        var leafNode = nodes.Last();

        if (leafNode is MethodStatementNode msn && currentScope.Resolve(msn.ID.Text) is MethodSymbol { MethodType: MethodType.Function }) {
            var otherNodes = nodes.SkipLast(1).ToArray();
            if (!otherNodes.Any(n => n is AssignmentNode or TernaryExpressionNode or LambdaExpressionNode or LetDefnNode or VarDefinitionNode || (n is FunctionDefinitionNode fdn && fdn.ReturnExpression == leafNode))
                && otherNodes.Last() is not MethodStatementNode) {
                return "Cannot have unassigned expression";
            }
        }

        return null;
    }

    private static bool Matches(ISymbolType? st, string name) =>
        st switch {
            GenericParameterType gpt1 when gpt1.Name == name => true,
            IHasElementsSymbolType hasElements when hasElements.ElementTypes.Any(et => Matches(et, name)) => true,
            _ => false
        };

    private static (int, ISymbolType) MatchParameter(string name, IScope scope) {
        var index = 0;
        foreach (var symbol in scope.Symbols) {
            var st = symbol.SymbolType;

            if (Matches(st, name)) {
                return (index, st!);
            }

            index++;
        }

        throw new ArgumentException(name);
    }

    private static GenericParameterType? IsOrUsesGenericParameterType(ISymbolType? st) {
        if (st is GenericParameterType gpt) {
            return gpt;
        }

        if (st is IHasElementsSymbolType tt) {
            return tt.ElementTypes.Select(IsOrUsesGenericParameterType).OfType<GenericParameterType>().FirstOrDefault();
        }

        return null;
    }


    public static string? ResolveGenericsTransform(IASTNode[] nodes, IScope currentScope) {
        var leafNode = nodes.Last();

        if (leafNode is MethodStatementNode m && m.ID.Text == "groupBy") {
            // break
        }


        if (leafNode is MethodStatementNode msn && currentScope.Resolve(msn.ID.Text) is GenericMethodSymbol gms) {
          
            var gpt = IsOrUsesGenericParameterType(gms.SymbolType);
            if (gpt is not null) {
                var (i, st) = MatchParameter(gpt.Name, gms);

                var parameterNode = msn.Parameters[i];

                var parameterNodeType = parameterNode.SymbolType;

                if (parameterNodeType is IUnresolvedType ut) {
                    parameterNodeType = ut.Resolve(currentScope);
                }

                var parameterDefinition = gms.Symbols.ToArray()[i];

                var actualGenericType = ExtractGenericType(parameterNodeType, parameterDefinition.SymbolType, gpt.Name) ?? throw new ArgumentException();

                var returnType = gms.SymbolType?.Clone() ?? throw new ArgumentException();

                msn.SymbolType = AssignGenericType(returnType, actualGenericType, gpt.Name);
            }
        }

        return null;
    }

    private static ISymbolType AssignGenericType(ISymbolType returnType, ISymbolType actualGenericType, string name) {
        if (returnType is GenericParameterType gpt) {
            if (gpt.Name == name) {
                return actualGenericType;
            }
        }

        return AssignGenericType1(returnType, actualGenericType, name);
    }

    private static ISymbolType AssignGenericType1(ISymbolType returnType, ISymbolType actualGenericType, string name)
    {
        if (returnType is IHasElementsSymbolType nodeType) {
            for (var index = 0; index < nodeType.ElementTypes.Length; index++) {
                var nt = nodeType.ElementTypes[index];
                if (nt is GenericParameterType gpt1) {
                    if (gpt1.Name == name) {
                        nodeType.ElementTypes[index] = actualGenericType;
                    }
                }
                AssignGenericType(nt, actualGenericType, name);
            }
        }

        return returnType;
    }


    private static ISymbolType? ExtractGenericType(ISymbolType parameterNodeType, ISymbolType? parameterDefinitionType, string name) {
        if (parameterDefinitionType is GenericParameterType gpt) {
            if (gpt.Name == name) {
                return parameterNodeType;
            }
        }

        if (parameterDefinitionType is IHasElementsSymbolType definition) {
            if (parameterNodeType is IHasElementsSymbolType nodeType) {
                var zip = definition.ElementTypes.Zip(nodeType.ElementTypes).ToArray();

                foreach (var (dt, nt) in zip) {
                    if (dt is GenericParameterType gpt1) {
                        if (gpt1.Name == name) {
                            return nt;
                        }
                    }
                }

                return zip.Select(t => ExtractGenericType(t.Second, t.First, name)).Single(i => i is not null);
            }

            throw new ArgumentException("");
        }

        return null;
    }

    public static string? TypeAssignmentRule(IASTNode[] nodes, IScope currentScope) {
        var node = nodes.Last();

        if (node is AssignmentNode an) {
            var lhsType = currentScope.Resolve(an.Id)?.SymbolType;
            var rhsType = an.SymbolType;

            if (lhsType is IUnresolvedType ut) {
                lhsType = ut.Resolve(currentScope);
            }

            if (rhsType is IUnresolvedType ut1) {
                rhsType = ut1.Resolve(currentScope);
            }

            //if (lhsType?.Equals(rhsType) == false) {
            //    return $"Cannot assign {rhsType} to {lhsType}";
            //}
        }

        return null;
    }
}