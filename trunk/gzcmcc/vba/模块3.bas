Attribute VB_Name = "Ä£¿é3"
Sub Macro3()
'
' Macro3 Macro
'

'
    k = 2
    For i = 2 To [A65535].End(xlUp).Row Step 10
    
    j = i + 9
    Sheets("sheet2").Select
    Range("N" & i & ":" & "W" & j).Select
    Selection.FormulaArray = "=MINVERSE(RC[-11]:R[9]C[-2])"
    Sheets("kValue").Select
    Range("AA" & k & ":" & "AJ" & k).Select
    Selection.FormulaArray = _
        "=MMULT(sheet2!RC[9]:R[9]C[18],Sheet2!RC[-3]:R[9]C[-3])"
    k = k + 1
    Next i
End Sub


