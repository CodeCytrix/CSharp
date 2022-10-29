using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas8.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/index.php");
string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas8:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);


string secret = decodeSecret("?????????????");

request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
request.Content = new FormUrlEncodedContent(new[] {
  new KeyValuePair<string, string>("secret", secret),
  new KeyValuePair<string, string>("submit", "Submit")
});


HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body) ;


string decodeSecret(string secret)
{
    List<char> t = new List<char>();
    for (int i = 0; i < secret.Length; i += 2)
        t.Add((char)Convert.ToByte(secret.Substring(i, 2), 16));
    t.Reverse();
    return Encoding.UTF8.GetString(Convert.FromBase64String(string.Join("", t)));
}
