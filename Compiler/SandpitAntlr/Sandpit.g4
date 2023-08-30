grammar Sandpit;
import Sandpit_Lexer;

file
	: (main |constantDef | classDef | functionDef | procedureDef)* NL* EOF
	;

main 
    : NL MAIN
      procedureBlock
      NL END MAIN 
    ;

constantDef: NL CONSTANT constantName ASSIGN expression;

classDef: abstractClass | mutableClass | immutableClass;

mutableClass: 
	NL CLASS className inherits?
    ( constructor |property | functionDef | procedureDef | constantDef)*	
    NL END CLASS
	;

immutableClass
	: NL IMMUTABLE CLASS className inherits?
    (constructor |property | functionDef | constantDef)*
    NL END CLASS 
	;

abstractClass:
	NL ABSTRACT CLASS className inherits?
    (property | NL FUNCTION functionSignature | NL PROCEDURE procedureSignature)*
    NL END CLASS
	;
 
inherits: INHERITS type (COMMA type)* ;

constructor: 
	NL CONSTRUCTOR (OPEN_BRACKET NL? parameterList? NL? CLOSE_BRACKET)? 
    functionBlock
	NL END CONSTRUCTOR
	;

property: NL PRIVATE? PROPERTY propertyName ( type | (ASSIGN expression)); 

functionDef: functionWithBody | expressionFunction;

functionWithBody: 
	NL FUNCTION functionSignature
	functionBlock
	NL RETURN expression
    NL END FUNCTION
	;

expressionFunction: 
	NL FUNCTION functionSignature NL? ARROW NL? letIn? expression; 

letIn: LET NL? assignableValue ASSIGN expression (COMMA assignableValue ASSIGN expression)* NL? IN NL?; 
   
functionSignature: functionName OPEN_BRACKET NL? parameterList? NL? CLOSE_BRACKET NL? AS NL? type;

procedureDef:
	NL PROCEDURE procedureSignature
	procedureBlock 
    NL END PROCEDURE
	;

procedureSignature: procedureName OPEN_BRACKET NL? parameterList? CLOSE_BRACKET;

procedureBlock:  ( procedureCall |constantDef | varDef | assignment | proceduralControlFlow | throwException)*;

functionBlock:  (constantDef | varDef | assignment | functionalControlFlow | throwException)* ;

varDef: NL VAR variableName ASSIGN expression;

assignment: NL assignableValue (ASSIGN | assignmentOp)  expression	;

procedureCall:  
	NL procedureName OPEN_BRACKET (argumentList)? CLOSE_BRACKET
	| NL closedExpression DOT procedureName OPEN_BRACKET (argumentList)? CLOSE_BRACKET 
	;

assignableValue: ((SELF DOT)?  valueName index?) | RESULT | tupleDecomp | listDecomp;

functionCall: (CURRY|PARTIAL)? functionName OPEN_BRACKET (argumentList)? CLOSE_BRACKET;

argumentList: expression (COMMA expression)*;

parameterList: parameter  (COMMA parameter)*;

parameter: NL? parameterName type; 

proceduralControlFlow: if  | for |  forIn | while | repeat | try | switch;

functionalControlFlow: if_functional  | for_functional |  forIn_functional | while_functional | repeat_functional | switch_functional;  //try...catch not permitted

if:	NL IF expression THEN
    procedureBlock
    (NL ELSE IF expression THEN
    procedureBlock)*
    (NL ELSE
    procedureBlock)?
    NL END IF
	;

if_functional:	NL IF expression THEN
    functionBlock
    (NL ELSE IF expression THEN
    functionBlock)*
    (NL ELSE
    functionBlock)?
    NL END IF
	;

for: 
	NL FOR variableName ASSIGN expression TO expression 
	procedureBlock
	NL END FOR
	;

for_functional: 
	NL FOR variableName ASSIGN expression TO expression 
	functionBlock
	NL END FOR
	;

forIn: 
	NL FOR variableName IN expression 
    procedureBlock
    NL END FOR
	;

forIn_functional: 
	NL FOR variableName IN expression 
    functionBlock
    NL END FOR
	;
          
while: 
	NL WHILE expression 
    procedureBlock
    NL END WHILE
	;

while_functional: 
	NL WHILE expression 
    functionBlock
    NL END WHILE
	;
          
repeat: 
	NL (REPEAT)
    procedureBlock
    NL UNTIL expression
	;

repeat_functional: 
	NL (REPEAT)
    functionBlock
    NL UNTIL expression
	;

try: 
	NL TRY 
    procedureBlock
    (NL CATCH variableName type 
	  procedureBlock)?
    NL END TRY
	;

try_functional: 
	NL TRY 
    functionBlock
    (NL CATCH variableName type 
	  functionBlock)?
    NL END TRY
	;

switch: 
	NL SWITCH expression
	  case*
      caseDefault?
	END SWITCH
	;

switch_functional: 
	NL SWITCH expression
	  case_functional*
      caseDefault_functional?
	END SWITCH
	;

case: 
	NL CASE literalValue
    procedureBlock
	;

case_functional: 
	NL CASE literalValue
    functionBlock
	;

caseDefault : 
	NL DEFAULT
    procedureBlock
	;

caseDefault_functional: 
	NL DEFAULT
    functionBlock
	;

expression
	: closedExpression  //Not clear how this works in relation 
	| unaryOp expression
	| expression binaryOp expression
	| newInstance
	| ifExpression
	| lambda
	| throwException
	| NL expression // so that any expression may be broken over multiple lines at its 'natural joints' i.e. before any sub-expression
	;

closedExpression:
	  bracketedExpression
	| functionCall
	| value
	| closedExpression index
	| closedExpression DOT functionCall
	| closedExpression DOT propertyName
	;

bracketedExpression: OPEN_BRACKET expression CLOSE_BRACKET ; //made into rule so that compiler can add the brackets explicitly

ifExpression: NL? IF expression NL? THEN expression NL? ELSE expression;

lambda: LAMBDA argumentList ARROW expression; 

throwException: THROW type (OPEN_BRACKET argumentList CLOSE_BRACKET);

index: OPEN_SQ_BRACKET (expression | expression COMMA expression | range) CLOSE_SQ_BRACKET;

range
	: expression DOUBLE_DOT expression 
	| expression DOUBLE_DOT
	| DOUBLE_DOT expression 
	; 

value: literalValue | ((SELF DOT)? valueName) | dataStructure | SELF | RESULT;

dataStructure: tuple | list | dictionary;

tuple:  OPEN_BRACKET expression COMMA expression (COMMA expression)* CLOSE_BRACKET; 

tupleDecomp: OPEN_BRACKET valueName (COMMA valueName)+  CLOSE_BRACKET;
 
list: OPEN_BRACE (NL? expression (COMMA expression)* NL?)? CLOSE_BRACE;

listDecomp: OPEN_BRACE valueName COLON valueName CLOSE_BRACE;

dictionary: OPEN_BRACE (NL? kvp (COMMA kvp)* NL?)? CLOSE_BRACE;

kvp: expression COLON expression;

assignmentOp: ASSIGN_ADD | ASSIGN_SUBTRACT | ASSIGN_MULT | ASSIGN_DIV; 

unaryOp: MINUS | OP_NOT;

binaryOp: arithmeticOp | logicalOp | conditionalOp ;

arithmeticOp:  POWER | MULT | DIVIDE | MOD | INT_DIV | PLUS | MINUS;

logicalOp: OP_AND | OP_OR | OP_XOR;

conditionalOp: GT | LT | OP_GE | OP_LE | OP_EQ | OP_NE;

literalValue:  BOOL_VALUE | LITERAL_INTEGER | LITERAL_FLOAT | LITERAL_DECIMAL| LITERAL_CHAR | LITERAL_STRING;

newInstance:
	NEW type OPEN_BRACKET (argumentList)? CLOSE_BRACKET (withClause)?
	| valueName withClause
	;

withClause: WITH OPEN_BRACE assignment (COMMA assignment)* CLOSE_BRACE;

type:  VALUE_TYPE | className | dataStructureType |  funcType | enumeration;

enumeration: NL ENUMERATION 
		     (enumValue (COMMA enumValue)*)  
			 NL END ENUMERATION;

enumValue: IDENTIFIER (ASSIGN LITERAL_INTEGER );

dataStructureType: arrayType | listType | dictionaryType | tupleType | iterableType | RANDOM;

tupleType: OPEN_BRACKET type (COMMA type)+ CLOSE_BRACKET; 

arrayType: ARRAY generic;

listType: LIST generic; 

dictionaryType: DICTIONARY generic;

iterableType: ITERABLE generic;

genericType: type generic;
    
generic: LT type GT;
    
funcType: OPEN_BRACKET type (COMMA type)*  ARROW type CLOSE_BRACKET;
    
className: IDENTIFIER; 
valueName: constantName | variableName | letName; 
constantName: IDENTIFIER;  
propertyName: IDENTIFIER;  
parameterName: IDENTIFIER;
variableName: IDENTIFIER;
letName: IDENTIFIER;
procedureName: IDENTIFIER;
functionName: IDENTIFIER;