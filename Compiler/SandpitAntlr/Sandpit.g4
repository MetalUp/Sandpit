grammar Sandpit;

file:   (constDecl | procDecl | funcDecl | mainDecl | NEWLINE)* ;

mainDecl
    : 'main' NEWLINE  procBody 'end main' NEWLINE
    ;

procDecl
    : 'procedure' ID '(' (param)* ')' NEWLINE procBody 'end procedure' NEWLINE
    ;

funcDecl
    : 'function' ID '(' (param)* ')' ':' type  NEWLINE funcBody 'end function' NEWLINE
    ;

constDecl
    : 'constant' ID '=' constVal NEWLINE
    ;

varDecl
    : 'var' ID '=' expr NEWLINE
    ;

letDecl
    : 'let' ID '=' expr NEWLINE
    ;

param
    : (ID ':' type)
    ;

constVal
    : INT
    | STRING
    | '{' constVal? (',' constVal)* '}'
    ;

expr 
    : constVal
    | ID
    ;

type 
    : 'Integer'
    | 'String'
    ;

procBody
    : varDecl+
    ;

funcBody
    : letDecl* 'return' expr NEWLINE
    ;


ID  :   LETTER (LETTER | [0-9])* ;

fragment
LETTER : [a-zA-Z] ;

INT :   [0-9]+ ;

STRING : '"' [ a-zA-Z0-9]* '"' ;

NEWLINE
  : '\r'? '\n'
  | '\r'
  ;

WS  :   [ \t]+ -> skip ;