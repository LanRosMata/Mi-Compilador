Imports System.Text.RegularExpressions

Public Class Principal
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtener la expresión matemática del TextBox
        Dim expresion As String = TextBox1.Text

        ' Utilizar expresiones regulares para separar los números y operadores
        Dim partes As MatchCollection = Regex.Matches(expresion, "[0-9]+|\+|\-|\*|\/")

        ' Convertir las partes de la expresión a valores numéricos y operadores
        Dim valores As New List(Of String)
        For Each parte As Match In partes
            valores.Add(parte.Value)
        Next

        ' Variable para almacenar el resultado final
        Dim resultado As Double = 0

        ' Realizar las operaciones de multiplicación y división primero
        Dim i As Integer = 0
        While i < valores.Count
            If valores(i) = "*" Then
                resultado = Convert.ToDouble(valores(i - 1)) * Convert.ToDouble(valores(i + 1))
                valores(i - 1) = resultado.ToString()
                valores.RemoveAt(i)
                valores.RemoveAt(i)
            ElseIf valores(i) = "/" Then
                resultado = Convert.ToDouble(valores(i - 1)) / Convert.ToDouble(valores(i + 1))
                valores(i - 1) = resultado.ToString()
                valores.RemoveAt(i)
                valores.RemoveAt(i)
            Else
                i += 1
            End If
        End While

        ' Realizar las operaciones de suma y resta después
        resultado = Convert.ToDouble(valores(0))
        For i = 1 To valores.Count - 1 Step 2
            If valores(i) = "+" Then
                resultado += Convert.ToDouble(valores(i + 1))
            ElseIf valores(i) = "-" Then
                resultado -= Convert.ToDouble(valores(i + 1))
            End If
        Next

        ' Mostrar el resultado en un MessageBox
        MessageBox.Show("El resultado de la operación es: " & resultado.ToString())
    End Sub

End Class
