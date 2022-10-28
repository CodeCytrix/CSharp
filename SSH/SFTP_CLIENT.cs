using Renci.SshNet;
using Renci.SshNet.Common;

// download
string file = "file.txt";
SftpClient sftpClient = new SftpClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
sftpClient.Connect();
FileStream fs = new FileStream(Path.GetFileName(file), FileMode.OpenOrCreate);
sftpClient.DownloadFile(file, fs);
sftpClient.Disconnect();


// upload
string file = "file.txt";
SftpClient sftpClient = new SftpClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
sftpClient.Connect();
FileStream fs = new FileStream(Path.GetFileName(file), FileMode.OpenOrCreate);
sftpClient.UploadFile(fs, file);
sftpClient.Disconnect();


// List Directory
SftpClient sftpClient = new SftpClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
sftpClient.Connect();
var files = sftpClient.ListDirectory("/");

foreach (var file in files)
{
    Console.WriteLine(file.Name);
}

sftpClient.Disconnect();


// Delete
SftpClient sftpClient = new SftpClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
sftpClient.Connect();
sftpClient.Delete("file.txt"); // or directory
sftpClient.Disconnect();