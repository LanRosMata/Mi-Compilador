# Mi Compilador

Este es un emulador basado en Visual Basic de un traductor, basado en un lenguaje que verifica solamente argumentos de operaciones numericas.
mostrando el analisis Semantico y Sintactico de los argumentos y mostrando una tabla de Simbolos y de expresiones para mostrar la generación de codigo simple.

las operaciones son las siguientes:

#Multiples.
Esta funcion realiza operaciones multiples como sumas, restas multiplicaciones, diviciones y tambien toma en cuenta los parentecis.
En el caso de parentesis es importante que se incluya antes y despues la operación a realizar con el resultado que esté dentro.
luego se finaliza con ";"

Sintaxis:

    EXP:
    a+b-(c+d)/e;

Tome en concideración que las letras deben son ejemplo y debe ser numero, ya que el traductor no contempla la declaración de variables.

Ejemplo:

    EXP:
    8+1-(10+5)/2*(4/2);
