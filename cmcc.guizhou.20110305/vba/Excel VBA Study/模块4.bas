Attribute VB_Name = "Ä£¿é4"
Sub Macro1()
'
' Macro1 Macro
'

'
    For k = 2 To [A65535].End(xlUp).Row
    Sheets("kValue").Select
    Range("AA" & k & ":" & "AJ" & k).Select

    i = 0
    
    Selection.FormulaArray = "=MMULT(sheet2!R[i]C[9]:R[i+9]C[18],sheet2!R[i]C[-3]:R[i+9]C[-3])"
    i = i + 9
   
    Next k

End Sub
Sub Macro2()
Attribute Macro2.VB_ProcData.VB_Invoke_Func = " \n14"
'
' Macro2 Macro
'

'

End Sub
