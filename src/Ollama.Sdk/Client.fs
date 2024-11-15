namespace Ollama.Sdk

module Ollama =
  [<Struct>]
  type Client = { model: string; connection: System.Net.Http.HttpClient }
  
  let inline connect (OllamaModel model) (Endpoint ep) =
    let client = new System.Net.Http.HttpClient()
    client.BaseAddress <- System.Uri($"http://{ep}/api")
    { model = model; connection = client }
    
  let inline disconnect (client: Client) = client.connection.Dispose()
  
  let inline generate (prompt: string) (client: Client) =
    let request = $"""
      {{
        "model": "{client.model}",
        "prompt": "{prompt}",
        "format": "json",
        "stream": false
      }}
    """
    use content = new System.Net.Http.StringContent(request)
    task {
      let! response = client.connection.PostAsync($"generate", content)
      return! response.Content.ReadAsStringAsync()
    }
