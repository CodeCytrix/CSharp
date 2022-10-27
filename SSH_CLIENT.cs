using Renci.SshNet;
using Renci.SshNet.Common;

SshClient Client = new SshClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
Client.Connect();

SshCommand cmd = Client.CreateCommand("cat readme");
cmd.Execute();

Client.Disconnect();

Console.WriteLine(cmd.Result);
