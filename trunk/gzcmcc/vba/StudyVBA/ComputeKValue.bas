Attribute VB_Name = "ComputeKValue"

Sub ComputeKValue()
'
' ComputeKValue
'

'
    Sheets("sheet2").Select
    Columns("N:W").Select
    Selection.ClearContents
    
    Sheets("kValue").Select
    Range("E2:N6").Select
    Selection.ClearContents

    
    Offset = 0
    k = 2
    
    
    Sheets("sheet2").Select
    
    
    For i = 2 To [A65535].End(xlUp).Row Step 10
    j = i + 9
    Sheets("sheet2").Select
    Range("N" & i & ":" & "W" & j).Select
    Selection.FormulaArray = "=MINVERSE(RC[-11]:R[9]C[-2])"
    Sheets("kValue").Select
    Range("E" & k & ":" & "N" & k).Select
    
    If Offset = 0 Then
    
    Selection.FormulaArray = _
        "=MMULT(Sheet2!RC[9]:R[" & Offset + 9 & "]C[18],Sheet2!RC[-3]:R[" & Offset + 9 & "]C[-3])"
        
    Else
    
        Selection.FormulaArray = _
        "=MMULT(Sheet2!R[" & Offset & "]C[9]:R[" & Offset + 9 & "]C[18],Sheet2!R[" & Offset & "]C[-3]:R[" & Offset + 9 & "]C[-3])"
    
    End If
    
    
        
    k = k + 1
    Offset = Offset + 9
    
    Next i
    
    
   '=MMULT(Sheet2!RC[9]:R[9]C[18],Sheet2!RC[-3]:R[9]C[-3])
   '=MMULT(Sheet2!R[ 9]C[9]:R[18]C[18],Sheet2!R[9]C[-3]:R[18]C[-3])"
   '=MMULT(Sheet2!R[18]C[9]:R[27]C[18],Sheet2!R[18]C[-3]:R[27]C[-3])"
   '  9       9       9   9

End Sub


