Mi Traductor de codigo


## Diseño de un Emulador de Traductor para Operaciones Matemáticas en Visual Basic.

Se ha diseñado un emulador de traductor exclusivamente para operaciones matemáticas en el lenguaje de programación Visual Basic. El traductor sigue una sintaxis predefinida para llevar a cabo diversas operaciones. El programa valida que la operación solicitada cumpla con los criterios y reglas establecidos. Durante este proceso, el traductor genera una tabla de símbolos que contiene todos los valores a evaluar. Posteriormente, divide las operaciones, generando un código intermedio y resolviendo cada una de ellas para obtener un resultado.

Este emulador funciona como un traductor y no como un compilador. Lee el código líneo por línea generando respuestas ::que se asignan a variables temporales, las cuales luego se agregan a la tabla de expresiones generando un código intermedio.

Los resultados del análisis semántico y sintáctico se muestran en el cuadro de resultados, donde también se muestran los resultados de las operaciones

----
                    

Las operaciones con sus palabras reservadas y sus expresiones son las siguientes:

#### Expresiones:
                

Son operaciones con múltiples operadores, estos paréntesis, siempre se debe especificar qué ocurrirá con este resultado después de obtener una después con el operador que se dese. 
Se inicia con la palabra ‘EXP’ seguido de ‘:’ y un salto de línea. Y se finaliza con un ‘;’.


##### Sintaxis:
                
 	EXP:
 	a+b-(c+d)/e;

##### Ejemplo
 	EXP:
 	3*(1-2)+10/2;

En el código, utilizamos pilas para almacenar uno por uno cada uno de los caracteres para ser evaluados, esto a manera de Tokens.

##### Operaciones de Suma y resta.

Estas operaciones tienen como palabra cable las siguientes: Sumas es ‘SUM’, Restas es ‘RESt’, Divisiones es con ‘DIV’ y Multiplicaciones es ‘MULT’.
La estructura requiere iniciar con la palabra reservada para hacer la operación luego inicia con corchetes ‘{‘ luego todos los números a calcular divididos por una coma ‘,’ y se finaliza cerrando corchetes ‘}’. Todos debe ser escrito en la misma línea y no requiere punto y coma ‘;’.

##### Sintaxis:

	SUM{a,b,c,d}

##### Ejemplo 1:

 	REST{90,7,15,6}

##### Ejemplo 2:

 	MULT{-8,9,2.5,5}

##### Ejemplo 3:

 	DIV{100,4,1}

##### Ejemplo 4:

 	SUM{6,3,7,8.9}

En ambos se puede usar numero enteros o reales, positivos y negativos y su tipo se especificará en la tabla de símbolos.
