open Ollama.Sdk

let client =
  Server.run()
  |> Ollama.connect OllamaModel.llama32

client
|> Ollama.generate "Hello, world!"
|> Async.AwaitTask
|> Async.RunSynchronously
|> printfn "%s"

client |> Ollama.disconnect