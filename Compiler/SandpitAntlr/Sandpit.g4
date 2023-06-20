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
    : 'constant' ID '=' INT NEWLINE
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

expr 
    : INT
    | ID
    ;

type 
    : 'Integer'
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

NEWLINE
  : '\r'? '\n'
  | '\r'
  ;

WS  :   [ \t]+ -> skip ;