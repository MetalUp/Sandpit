grammar Sandpit;

file:   (constDecl | procDecl | mainDecl | NEWLINE)* ;

mainDecl
    : 'main' NEWLINE  varDecl+  'end main' NEWLINE
    ;

procDecl
    : 'procedure' ID '(' ')' NEWLINE varDecl+  'end procedure' NEWLINE
    ;

constDecl
    : 'constant' ID '=' INT NEWLINE
    ;

varDecl
    : 'var' ID ('=' expr)? NEWLINE
    ;

expr 
    : INT
    | ID
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