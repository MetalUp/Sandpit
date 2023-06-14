grammar Sandpit;

file:   (constDecl | mainDecl | NEWLINE)* ;

mainDecl
    : 'main' NEWLINE  varDecl+  'end main' NEWLINE
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