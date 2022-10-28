using System.Net.Http;
using System.Text;


// Reqest GET Method
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://some.server.com");
HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "/index.html");

HttpResponseMessage httpResponse = await client.SendAsync(msg);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body);



// Request with UserAgent
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://some.server.com");
HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "/index.html");
msg.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.24");

HttpResponseMessage httpResponse = await client.SendAsync(msg);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body);



// Request Head Method
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://some.server.com");
HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Head, "/index.html");

HttpResponseMessage httpResponse = await client.SendAsync(msg);
httpResponse.EnsureSuccessStatusCode();
Console.WriteLine(httpResponse);



// Request with Basic Credential
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://some.server.com");

string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("user:password"));
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.html");
request.Headers.Add("Authorization", "Basic " + credential);

HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body)
