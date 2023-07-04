grammar Sandpit;

import Sandpit_Lexer;

file
	: (main |constantDef | classDef | procedureDef | functionDef)* SOL* EOF
	;

main 
    : SOL MAIN
      procedureBlock
      SOL END MAIN 
    ;

constantDef: SOL CONSTANT constantName ASSIGN expression;

classDef: abstractClass | mutableClass | immutableClass;

mutableClass: 
	SOL CLASS className inherits?
    (SOL (constructor | property | functionMethod | procedureMethod | constantDef))*
    SOL END CLASS
	;

immutableClass
	: SOL IMMUTABLE CLASS className inherits?
    (SOL (constructor | property | functionMethod | constantDef))*
    SOL END CLASS 
	;

abstractClass:
	SOL ABSTRACT CLASS className inherits?
    (SOL ( property | functionSignature | procedureSignature))*
    SOL END CLASS
	;
 
inherits: INHERITS type (COMMA type)* ;

procedureMethod:
	SOL PRIVATE? METHOD procedureSignature
	procedureBlock
	SOL END METHOD
	;

functionMethod:
	SOL PRIVATE? METHOD functionSignature  //TODO Doesn't currently permit expression syntax for function methods
	functionBlock
	SOL END METHOD
	;

functionDef: functionWithBody | expressionFunction;

functionWithBody: 
	SOL FUNCTION functionSignature
	functionBlock
	SOL RETURN expression
    SOL END FUNCTION
	;

expressionFunction: 
	SOL FUNCTION functionSignature SOL? ARROW SOL? expression; 
   
functionSignature: functionName OPEN_BRACKET parameterList CLOSE_BRACKET AS type;

procedureDef:
	SOL PROCEDURE procedureSignature
	procedureBlock 
    SOL END PROCEDURE
	;

procedureSignature: procedureName OPEN_BRACKET parameterList? CLOSE_BRACKET;

constructor: 
	SOL CONSTRUCTOR (OPEN_BRACKET parameterList CLOSE_BRACKET)? 
    procedureBlock
	SOL END CONSTRUCTOR
	;

property: SOL PRIVATE? PROPERTY propertyName ( type | (ASSIGN literal));

procedureBlock:  (procedureStatement)*;

functionBlock:  (functionStatement)* ;

procedureStatement: systemCall | functionStatement | procedureCall;

functionStatement: constantDef | varDef | assignment | controlFlowStatement;

systemCall: SOL VAR variableName ASSIGN systemKeyword
			| SOL assignableValue ASSIGN systemKeyword
			; 

systemKeyword: (INPUT | RANDOM | TODAY | NOW);

varDef: SOL VAR variableName ASSIGN expression;

assignment: SOL (PROP|PARAM)? assignableValue (ASSIGN | assignmentOp)  expression	;

procedureCall: 
	SOL (expression DOT)? procedureName OPEN_BRACKET (argumentList)? CLOSE_BRACKET
	; 

argumentList: expression (COMMA expression)*;  //TODO should support any expression but need to get round mutual self-recursion

parameterList: parameter  (COMMA parameter)*;

parameter: SOL? parameterName type; 

assignmentOp: ASSIGN_ADD | ASSIGN_SUBTRACT | ASSIGN_MULT | ASSIGN_DIV; 

unaryOp: MINUS | OP_NOT;

binaryOp: arithmeticOp | logicalOp | conditionalOp ;//TODO check for precedence

arithmeticOp:  POWER | MULT | DIVIDE | MOD | INT_DIV | PLUS | MINUS;

logicalOp: OP_AND | OP_OR | OP_XOR;

conditionalOp: GT | LT | OP_GE | OP_LE | OP_EQ | OP_NE;

controlFlowStatement: if  | for |  forIn | while | repeat | try | switch;

if:	SOL IF expression THEN
    procedureBlock
    (SOL ELSE IF expression THEN
    procedureBlock)*
    (SOL ELSE
    procedureBlock)?
    SOL END IF
	;

for: 
	SOL FOR variableName ASSIGN expression 'to'  expression 
	procedureBlock
	SOL ((END FOR) | (NEXT variableName))
	;

forIn: 
	SOL FOR variableName IN expression 
    procedureBlock
    SOL ((END FOR) | (NEXT variableName))
	;
          
while: 
	SOL WHILE expression 
    procedureBlock
    SOL END WHILE
	;
          
repeat: 
	SOL REPEAT | DO
    procedureBlock
    SOL  UNTIL expression
	;

try: 
	SOL TRY 
    procedureBlock
    (SOL CATCH'catch' variableName type 
	  procedureBlock)?
    SOL END TRY
	;

switch: 
	SOL SWITCH expression COLON
	  case*
      case_default?
	END SWITCH
	;

case: 
	SOL CASE COLON
    procedureBlock
	;

case_default : 
	SOL DEFAULT COLON
    procedureBlock
	;

expression
	:  LINE_CONTINUATION expression 
	| simpleExpression  
	| sliceOfList
	| unaryOp expression
	| expression binaryOp expression
	| functionCall 
	| expression DOT functionCall 
	| instantiation
	| ifExpression
	| OPEN_BRACKET expression CLOSE_BRACKET
	| lambda
	| letIn expression
	| expression index 
	;

ifExpression: SOL? IF SOL? expression SOL? THEN SOL? expression SOL? ELSE SOL? expression;

lambda: LAMBDA argumentList ARROW expression; 

letIn: LET SOL? assignableValue ASSIGN expression (COMMA variableName ASSIGN expression)* SOL? IN SOL?; 

simpleExpression: literal |  valueName | tupleValue; 

tupleValue: OPEN_BRACKET expression (COMMA expression)+ CLOSE_BRACKET;

index: OPEN_SQ_BRACKET (expression | expression COMMA expression) CLOSE_SQ_BRACKET; 
 
sliceOfList: valueName OPEN_SQ_BRACKET range CLOSE_SQ_BRACKET;

range
	: expression DOUBLE_DOT expression 
	| expression DOUBLE_DOT
	| DOUBLE_DOT expression 
	; 

assignableValue: valueName index? | tupleDecomp | listDecomp;

tupleDecomp: OPEN_BRACKET valueName (COMMA valueName)+  CLOSE_BRACKET;

listDecomp: OPEN_BRACE valueName COLON valueName CLOSE_BRACE;

literal: literalValue | literalDataStructure;

literalValue:  bool | integer | float | decimal | char | string;

bool: BOOL;
integer: LITERAL_INTEGER;
float: LITERAL_FLOAT;
decimal : LITERAL_DECIMAL;
char: LITERAL_CHAR;
string:  LITERAL_STRING;

literalDataStructure: literalList | literalDictionary;

literalList: OPEN_BRACE (literal (COMMA literal)*)? CLOSE_BRACE;

literalDictionary: OPEN_BRACE (kvp (COMMA kvp)*)? CLOSE_BRACE;

kvp: literal COLON literal;

functionCall: functionName OPEN_BRACKET (argumentList)? CLOSE_BRACKET;

instantiation:
	NEW type OPEN_BRACKET (argumentList)? CLOSE_BRACKET (withClause)?
	| valueName withClause
	;

withClause: WITH OPEN_BRACE assignment (COMMA assignment)* CLOSE_BRACE;

type: VALUE_TYPE | tupleType | dataStructureType | className | funcType;

dataStructureType: arrayType | listType | dictionaryType;

tupleType: OPEN_BRACKET type (COMMA type)+ CLOSE_BRACKET; 

arrayType: ARRAY generic;

listType: LIST generic;

dictionaryType: DICTIONARY generic;
    
generic: LT type GT;
    
funcType: OPEN_BRACKET type (COMMA type)*  ARROW type CLOSE_BRACKET;
    
className: TYPENAME;  
valueName: constantName | variableName | letName; 
constantName: IDENTIFIER;  
propertyName: IDENTIFIER;  
parameterName: IDENTIFIER;
variableName: IDENTIFIER;
letName: IDENTIFIER;
procedureName: IDENTIFIER;
functionName: IDENTIFIER;