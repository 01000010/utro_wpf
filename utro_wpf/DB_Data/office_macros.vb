Sub RemoveNonNumeric()

    Dim Rng As Range
    Dim WorkRng As Range
    On Error Resume Next
    xTitleId = "Make numeric"
    WorkRng = Application.Selection
    WorkRng = Application.InputBox("Range", xTitleId, WorkRng.Address, Type:=8)
    For Each Rng In WorkRng
        xOut = ""
        For i = 1 To Len(Rng.Value)
            xTemp = Mid(Rng.Value, i, 1)
            If xTemp Like "[0-9]" Then
                xStr = xTemp
            Else
                xStr = ""
            End If
            xOut = xOut & xStr
        Next i
        Rng.Value = xOut
    Next

End Sub

Sub RemoveNonNumericWithDecimalPoint()

    Dim Rng As Range
    Dim WorkRng As Range
    On Error Resume Next
    xTitleId = "Make numeric with decimal point"
    WorkRng = Application.Selection
    WorkRng = Application.InputBox("Range", xTitleId, WorkRng.Address, Type:=8)
    For Each Rng In WorkRng
        xOut = ""
        For i = 1 To Len(Rng.Value)
            xTemp = Mid(Rng.Value, i, 1)
            If xTemp Like "[0-9.]" Then
                xStr = xTemp
            Else
                xStr = ""
            End If
            xOut = xOut & xStr
        Next i
        Rng.Value = xOut
    Next

End Sub