Sub CombineWorkbooks()
    
    Dim FilesToOpen
    Dim x As Integer
    Application.DisplayAlerts = False
    Application.ScreenUpdating = True
    FilesToOpen = Application.GetOpenFilename(FileFilter:="Micrsofe Excel文件(*.xls), *.xls", MultiSelect:=True, Title:="要合并的文件")
   ' If FilesToOpen = False Then GoTo Cancel
   
    Set sk = Workbooks.Open(Filename:="E:\book1.xls")         '注：自己修改路径
    For x = 1 To UBound(FilesToOpen)
    
        Set wk = Workbooks.Open(Filename:=FilesToOpen(x))
        
        wk.Sheets("原始话统").Activate
        Range("E2:G2").Select
        Range(Selection, Selection.End(xlDown)).Select
        Selection.Activate
        Selection.Copy

        sk.Sheets("sheet1").Activate
        Cells(Range("A65536").End(xlUp).Row + 1, 1).Select
        ActiveSheet.Paste
        
        wk.Sheets("原始话统").Activate
        Range("C2").Select
        Range(Selection, Selection.End(xlDown)).Select
        Selection.Activate
        Selection.Copy

        sk.Sheets("sheet1").Activate
        Cells(Range("D65536").End(xlUp).Row + 1, 4).Select
        ActiveSheet.Paste
        
        wk.Sheets("原始话统").Activate
        Range("AF2:AH2").Select
        Range(Selection, Selection.End(xlDown)).Select
        Selection.Activate
        Selection.Copy

        sk.Sheets("sheet1").Activate
        Cells(Range("E65536").End(xlUp).Row + 1, 5).Select
        ActiveSheet.Paste
        
        
        sk.Save                     '保存修改
        'sk.Close
        wk.Close
        


    Next x
    MsgBox "合并成功完成！"
 End Sub

