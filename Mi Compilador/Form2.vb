Imports System.Runtime.InteropServices

Public Class Form2


    Public Class LineNumberRichTextBox
        Inherits RichTextBox

        Private lineNumbersWidth As Integer = 35 ' Ancho de la barra de números de línea
        Private Const WM_PAINT As Integer = &HF

        <DllImport("user32.dll")>
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function

        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)

            If m.Msg = WM_PAINT Then
                DrawLineNumbers()
            End If
        End Sub

        Private Sub DrawLineNumbers()
            Dim g As Graphics = Me.CreateGraphics()
            Dim font As Font = New Font(Me.Font, FontStyle.Regular)
            Dim brush As Brush = New SolidBrush(Color.Gray)
            Dim lineHeight As Integer = Me.GetPositionFromCharIndex(Me.GetFirstCharIndexFromLine(1)).Y - Me.GetPositionFromCharIndex(Me.GetFirstCharIndexFromLine(0)).Y
            Dim firstIndex As Integer = Me.GetCharIndexFromPosition(New Point(0, 0))
            Dim firstLine As Integer = Me.GetLineFromCharIndex(firstIndex)
            Dim firstLineY As Integer = Me.GetPositionFromCharIndex(firstIndex).Y
            Dim lineNumber As Integer = firstLine + 1
            Dim line As String = ""

            Dim rect As Rectangle = New Rectangle(0, 0, lineNumbersWidth, Me.Height)

            g.FillRectangle(New SolidBrush(Me.BackColor), rect)
            g.DrawString(lineNumber.ToString(), font, brush, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

            While firstLineY < Me.Height
                firstLine += 1
                firstLineY += lineHeight
                rect.Y = firstLineY
                rect.X = 0

                If rect.Y < Me.Height Then
                    g.FillRectangle(New SolidBrush(Me.BackColor), rect)
                    line = (firstLine + 1).ToString()
                    g.DrawString(line, font, brush, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If
            End While

            g.Dispose()
        End Sub
    End Class


    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class