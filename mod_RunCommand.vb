Module mod_RunCommand
    Dim txtOut As String = ""

    Function RunCommand(ByVal strProc As String, ByVal strArgs As String) As String
        On Error GoTo ErrO
        Dim process As New Process()
        txtOut = ""
        process.StartInfo.FileName = strProc
        process.StartInfo.Arguments = strArgs
        process.StartInfo.UseShellExecute = False
        process.StartInfo.CreateNoWindow = True
        process.StartInfo.RedirectStandardOutput = True
        AddHandler process.OutputDataReceived, AddressOf OutputHandler
        process.Start()
        process.BeginOutputReadLine()
        process.WaitForExit()
        process.Close()
        Return txtOut
ErrO:

    End Function

    Sub OutputHandler(sender As Object, e As DataReceivedEventArgs)
        txtOut = txtOut & e.Data & vbCrLf
    End Sub

End Module
