grammar Sandpit;

file:   (constDecl | procDecl | funcDecl | mainDecl | NEWLINE)* ;

mainDecl
    : 'main' NEWLINE  varDecl+  'end main' NEWLINE
    ;

procDecl
    : 'procedure' ID '(' (param)* ')' NEWLINE varDecl+  'end procedure' NEWLINE
    ;

funcDecl
    : 'function' ID '(' (param)* ')' ':' type  NEWLINE letDecl+  'end function' NEWLINE
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

ID  :   LETTER (LETTER | [0-9])* ;

fragment
LETTER : [a-zA-Z] ;

INT :   [0-9]+ ;

NEWLINE
  : '\r'? '\n'
  | '\r'
  ;

WS  :   [ \t]+ -> skip ;