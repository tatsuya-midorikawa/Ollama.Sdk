namespace Ollama.Sdk

[<Struct>]
type Endpoint = Endpoint of string

module Network =
  let inline findFreePort () =
    use sock = new System.Net.Sockets.Socket(
        System.Net.Sockets.AddressFamily.InterNetwork,
        System.Net.Sockets.SocketType.Stream,
        System.Net.Sockets.ProtocolType.Tcp)
    sock.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0))
    let ep = sock.LocalEndPoint :?> System.Net.IPEndPoint
    ep.Port