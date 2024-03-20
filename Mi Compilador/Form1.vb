Imports System.Text.RegularExpressions

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtener la expresión matemática del TextBox
        Dim expresion As String = TextBox1.Text

        ' Utilizar expresiones regulares para separar los números y operadores
        Dim partes As MatchCollection = Regex.Matches(expresion, "[0-9]+|\+|\-|\*|\/|\(|\)|SUM")

        ' Convertir las partes de la expresión a una lista
        Dim valores As New List(Of String)
        For Each parte As Match In partes
            valores.Add(parte.Value)
            ListBox1.Items.Add(parte.Value)
        Next

        ' Evaluar las expresiones dentro de paréntesis primero
        EvaluarParentesis(valores)

        ' Realizar las operaciones de multiplicación y división
        EvaluarOperadores("*", valores)
        EvaluarOperadores("/", valores)

        ' Realizar las operaciones de suma y resta
        Dim resultado As Double = Convert.ToDouble(valores(0))
        For i As Integer = 1 To valores.Count - 1 Step 2
            If valores(i) = "+" Then
                resultado += Convert.ToDouble(valores(i + 1))
            ElseIf valores(i) = "-" Then
                resultado -= Convert.ToDouble(valores(i + 1))
            End If
        Next

        ' Mostrar el resultado en un MessageBox
        MessageBox.Show("El resultado de la operación es: " & resultado.ToString())
    End Sub

    Private Sub EvaluarParentesis(ByRef valores As List(Of String))
        Dim pila As New Stack(Of Integer)
        Dim i As Integer = 0

        While i < valores.Count
            If valores(i) = "(" Then
                pila.Push(i)
            ElseIf valores(i) = ")" Then
                If pila.Count > 0 Then
                    Dim inicioParentesis As Integer = pila.Pop()
                    Dim subExpresion As New List(Of String)(valores.GetRange(inicioParentesis + 1, i - inicioParentesis - 1))
                    EvaluarOperadores("*", subExpresion)
                    EvaluarOperadores("/", subExpresion)
                    valores.RemoveRange(inicioParentesis, i - inicioParentesis + 1)
                    valores.InsertRange(inicioParentesis, subExpresion)
                    i -= (i - inicioParentesis + 1)
                Else
                    ' Error: Paréntesis de cierre sin paréntesis de apertura correspondiente
                    MessageBox.Show("Error: Paréntesis de cierre sin paréntesis de apertura correspondiente.")
                    Exit Sub ' Salir de la función si encontramos un error
                End If
            End If
            i += 1
        End While

        If pila.Count > 0 Then
            ' Error: Paréntesis de apertura sin paréntesis de cierre correspondiente
            MessageBox.Show("Error: Paréntesis de apertura sin paréntesis de cierre correspondiente.")
        End If
    End Sub


    Private Sub EvaluarOperadores(ByVal operador As String, ByRef valores As List(Of String))
        Dim i As Integer = 1
        While i < valores.Count - 1
            If valores(i) = operador Then
                Dim operando1 As Double
                If Double.TryParse(valores(i - 1), operando1) Then
                    Dim operando2 As Double
                    If Double.TryParse(valores(i + 1), operando2) Then
                        Dim resultado As Double

                        Select Case operador
                            Case "*"
                                resultado = operando1 * operando2
                            Case "/"
                                resultado = operando1 / operando2
                        End Select

                        valores(i - 1) = resultado.ToString()
                        valores.RemoveAt(i)
                        valores.RemoveAt(i)
                    Else
                        i += 2
                    End If
                Else
                    i += 2
                End If
            Else
                i += 2
            End If
        End While
    End Sub


    ' Cambio de color
    '------------------------------------------------------------------------





    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        ' Guarda la posición actual del cursor para no alterarla al cambiar el color
        Dim currentPosition As Integer = RichTextBox1.SelectionStart

        ' Expresión regular para buscar palabras clave, operadores y otros símbolos
        Dim regex As New Regex("(SUM|REST|DIV|MULT|\+|\-|\*|\/|\(|\)|\{|\}|;|:|,)", RegexOptions.IgnoreCase)

        ' Busca todas las coincidencias de palabras clave, operadores y símbolos en el texto
        Dim matches As MatchCollection = regex.Matches(RichTextBox1.Text)

        ' Guarda la posición inicial de la selección para restaurarla después
        Dim selectionStart As Integer = RichTextBox1.SelectionStart
        Dim selectionLength As Integer = RichTextBox1.SelectionLength

        ' Restaura el color del texto completo
        RichTextBox1.SelectAll()
        RichTextBox1.SelectionColor = RichTextBox1.ForeColor

        ' Itera sobre las coincidencias y cambia el color según la palabra clave, operador o símbolo
        For Each match As Match In matches
            Dim startIndex As Integer = match.Index
            Dim length As Integer = match.Length
            Dim color As Color = RichTextBox1.ForeColor

            Select Case match.Value.ToUpper()
                Case "SUM", "REST", "DIV", "MULT"
                    color = Color.Blue
                Case "+", "-", "*", "/", ","
                    color = Color.Red
                Case "(", ")"
                    color = Color.Gray
                Case "{", "}"
                    color = Color.Gray
                Case ";", ":"
                    color = Color.Violet
            End Select

            RichTextBox1.Select(startIndex, length)
            RichTextBox1.SelectionColor = color
        Next

        ' Restaura la posición del cursor al valor original
        RichTextBox1.Select(selectionStart, selectionLength)

        ' Restaura el color de la selección
        RichTextBox1.SelectionColor = RichTextBox1.ForeColor
        RichTextBox1.SelectionStart = currentPosition
        RichTextBox1.SelectionLength = 0
    End Sub

End Class
