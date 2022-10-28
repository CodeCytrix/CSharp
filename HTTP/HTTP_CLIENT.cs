using System.Net.Http;

// Request Head Method
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://overthewire.org");
HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Head, "/wargames/index.html");
msg.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.24");

HttpResponseMessage httpResponse = await client.SendAsync(msg);
httpResponse.EnsureSuccessStatusCode();
Console.WriteLine(httpResponse);



// Reqest GET Method
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://overthewire.org");
HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "/wargames/index.html");
msg.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.24");

HttpResponseMessage httpResponse = await client.SendAsync(msg);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body);
