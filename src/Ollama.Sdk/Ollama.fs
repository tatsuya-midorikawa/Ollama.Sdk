namespace Ollama.Sdk

[<Struct>]
type OllamaModel = OllamaModel of string
module OllamaModel =
  let llama32 = OllamaModel "llama3.2"
  let llama32'1b = OllamaModel "llama3.2:1b"
  let llama32'vision = OllamaModel "llama3.2-vision"
  let llama32'vision90b = OllamaModel "lllama3.2-vision:90b"
  let llama31 = OllamaModel "llama3.1"
  let llama31'70b = OllamaModel "llama3.1:70b"
  let llama31'405b = OllamaModel "llama3.1:405b"
  let phi3 = OllamaModel "phi3"
  let phi3'medium = OllamaModel "phi3:medium"
  let gemma2 = OllamaModel "gemma2"
  let gemma2'2b = OllamaModel "gemma2:2b"
  let gemma2'27b = OllamaModel "gemma2:27b"
  let mistral = OllamaModel "mistral"
  let moondream = OllamaModel "moondream"
  let neuralchat = OllamaModel "neural-chat"
  let starling = OllamaModel "starling-lm"
  let codellama = OllamaModel "codellama"
  let llama2'uncensored = OllamaModel "llama2-uncensored"
  let llava = OllamaModel "llava"
  let solar = OllamaModel "solar"