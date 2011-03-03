Attribute VB_Name = "Ä£¿é1"

Sub Macro1()
'

'
'i = 2
Sheets("sheet1").Select

For i = 2 To [A65535].End(xlUp).Row

Select Case Range("Q" & i)

Case 0 To 1

    Range("D" & i) = Sheets("kValue").Range("E2").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F2").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G2").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H2").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I2").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J2").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K2").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L2").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M2").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N2").Value

Case 1 To 2

    Range("D" & i) = Sheets("kValue").Range("E3").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F3").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G3").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H3").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I3").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J3").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K3").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L3").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M3").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N3").Value


    
Case 2 To 3

    Range("D" & i) = Sheets("kValue").Range("E4").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F4").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G4").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H4").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I4").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J4").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K4").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L4").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M4").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N4").Value


Case 3 To 4

    Range("D" & i) = Sheets("kValue").Range("E5").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F5").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G5").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H5").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I5").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J5").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K5").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L5").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M5").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N5").Value


Case 4 To 5
     
    Range("D" & i) = Sheets("kValue").Range("E6").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F6").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G6").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H6").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I6").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J6").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K6").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L6").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M6").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N6").Value


Case 5 To 6

    Range("D" & i) = Sheets("kValue").Range("E7").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F7").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G7").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H7").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I7").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J7").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K7").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L7").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M7").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N7").Value


Case Is >= 6

    Range("D" & i) = Sheets("kValue").Range("E8").Value + _
    Range("F" & i).Value * Sheets("kValue").Range("F8").Value + _
    Range("G" & i).Value * Sheets("kValue").Range("G8").Value + _
    Range("H" & i).Value * Sheets("kValue").Range("H8").Value + _
    Range("I" & i).Value * Sheets("kValue").Range("I8").Value + _
    Range("J" & i).Value * Sheets("kValue").Range("J8").Value + _
    Range("K" & i).Value * Sheets("kValue").Range("K8").Value + _
    Range("L" & i).Value * Sheets("kValue").Range("L8").Value + _
    Range("M" & i).Value * Sheets("kValue").Range("M8").Value + _
    Range("N" & i).Value * Sheets("kValue").Range("N8").Value


End Select

Next i


    'ActiveWorkbook.Save
End Sub


