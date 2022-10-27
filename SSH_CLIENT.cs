using Renci.SshNet;
using Renci.SshNet.Common;
using System.Text.RegularExpressions;

// login with password
SshClient Client = new SshClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
Client.Connect();

// Login with Key
PrivateKeyFile key = new PrivateKeyFile("file.key");
SshClient Client = new SshClient("bandit.labs.overthewire.org", 2220, "bandit0", key);
Client.Connect()

SshCommand cmd = Client.CreateCommand("cat readme");
cmd.Execute();

Client.Disconnect();

Console.WriteLine(cmd.Result);