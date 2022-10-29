HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas11.natas.labs.overthewire.org");

HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");


string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas11:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);

string key = GetKey("{\"showpassword\":\"no\",\"bgcolor\":\"#ffffff\"}", "???????????????????????????????????????");

request.Headers.Add("Cookie", "data="+MakeKey("{\"showpassword\":\"yes\",\"bgcolor\":\"#ffffff\"}", key));

HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(body) ;

// Console.WriteLine(httpResponse.Headers); // Get encrypted Key from Header

string GetKey(string json, string cookie)
{
    cookie = Encoding.UTF8.GetString(Convert.FromBase64String(cookie));
    StringBuilder cyphertext = new StringBuilder(json.Length);
    for (int i = 0; i < json.Length; ++i)
        cyphertext.Append((char)(json[i] ^ cookie[i % cookie.Length]));

    return cyphertext.ToString().Substring(0, 4);
}


string MakeKey(string json, string key)
{
    StringBuilder cyphertext = new StringBuilder(json.Length);
    for (int i = 0; i < json.Length; ++i)
        cyphertext.Append((char)(json[i] ^ key[i % key.Length]));

    return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(cyphertext.ToString()));
}
