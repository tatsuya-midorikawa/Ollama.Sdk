module Ollama.Sdk.Server

open System.Runtime.InteropServices

let inline run () =
  let port = Network.findFreePort()
  let ep = $"127.0.0.1:{port}"
  let eoc = "echo \"::End of command::\""
  
  let mkpsi path =
    System.Diagnostics.ProcessStartInfo(
      path, UseShellExecute = false,
      RedirectStandardOutput = true, RedirectStandardInput = true,
      WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden, CreateNoWindow = true)
    
  let exec (cmd: string) (prc: System.Diagnostics.Process) =
    printfn $"{cmd}"
    prc.StandardInput.WriteLine cmd
    prc.StandardInput.WriteLine eoc
    let mutable s = prc.StandardOutput.ReadLine()
    while s <> Unchecked.defaultof<_> && not <| s.EndsWith eoc do
      s <- prc.StandardOutput.ReadLine()
  
  if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
    printfn "Running on Windows"
    raise (System.NotImplementedException())
  else if RuntimeInformation.IsOSPlatform(OSPlatform.OSX) then
    printfn "Running on OSX"
    let psi = mkpsi "/bin/zsh"
    let prc = System.Diagnostics.Process.Start(psi)
    prc |> exec $"export OLLAMA_HOST={ep}"
    prc |> exec $"ollama serve"
  else
    printfn "Running on Unix"
    raise (System.NotImplementedException())
  Endpoint ep