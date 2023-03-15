using System;
using System.Linq;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord.Audio;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp3
{
    public class NRJ
    {
        DiscordSocketClient _client;
        static void Main(string[] args)
        {
            new NRJ().MainAsync().GetAwaiter().GetResult();
        }
        public NRJ()
        {
            ServicePointManager.Expect100Continue = true;
            _client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Debug });
        }
        public async Task MainAsync()
        {
            Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         Veuillez patienter...");
            _client.Log += Log;
            await _client.LoginAsync(0, "USER TOKEN");
            await _client.StartAsync();
            _client.Ready += async () =>
            {
                Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         Bot connécté");
                return;

            };
            await Task.Delay(10000);

            new Thread(new ThreadStart(async () =>
            {
                Random rdm = new Random();
                SocketTextChannel chnl = (_client.GetChannel(783983795568377896) as SocketTextChannel);
                var tab = new string[4] { "e", "n", "r", "d" };
                while (true)
                {
                    await chnl.TriggerTypingAsync();
                    await Task.Delay(rdm.Next(1000, 3000));
                    await chnl.SendMessageAsync("pls beg");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         \"pls beg\" envoyé");
                    await chnl.TriggerTypingAsync();
                    await Task.Delay(rdm.Next(1000, 3000));
                    await chnl.SendMessageAsync("pls hunt");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         \"pls hunt\" envoyé");
                    await chnl.TriggerTypingAsync();
                    await Task.Delay(rdm.Next(1000, 3000));
                    await chnl.SendMessageAsync("pls fish");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         \"pls fish\" envoyé");
                    await chnl.TriggerTypingAsync();
                    await Task.Delay(rdm.Next(1000, 3000));
                    await chnl.SendMessageAsync("pls pm");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         Début de l'attente (cooldown = 45s)");
                    await Task.Delay(45000 + rdm.Next(2000));
                }
            })).Start();
                _client.MessageReceived += async (x) =>
                {
                    new Thread(new ParameterizedThreadStart(async (obj) =>
                    {
                        var msg = (obj as SocketMessage);
                        if(msg.Channel.Id == 783983795568377896 && msg.Author.Id == 270904126974590976)
                        {
                            if(msg.Content.Contains("10 seconds") && msg.Content.Contains("`"))
                            {
                                await msg.Channel.SendMessageAsync(msg.Content.Split("`")[1]);
                            }
                        }
                    })).Start(x);
                 };

            new Thread(new ThreadStart(async () =>
            {
                Random rdm = new Random();
                SocketTextChannel chnl = (_client.GetChannel(781415325949362228) as SocketTextChannel);
                while (true)
                {
                    await chnl.SendMessageAsync("!breedpet");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         \"!breedpet\" envoyé");
                    await Task.Delay(7200000 + rdm.Next(5000));
                }
            })).Start();

            new Thread(new ThreadStart(async () =>
            {
                Random rdm = new Random();
                SocketTextChannel chnl = (_client.GetChannel(781415325949362228) as SocketTextChannel);
                while (true)
                {
                    await chnl.SendMessageAsync("pls dep all");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{DateTime.Now.TimeOfDay.ToString().Remove(8)} Bot         \"pls dep all\" envoyé");
                    await Task.Delay(600000 + rdm.Next(5000));
                }
            })).Start();
            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            if (msg.ToString().Contains("Gateway     Sent StatusUpdate") || msg.ToString().Contains("Gateway     Received Dispatch (PRESENCE_UPDATE)") || msg.ToString().Contains("INVITE_CREATE") || msg.ToString().Contains("Failed to resume previous session") || msg.ToString().Contains("Server requested a reconnect") || msg.ToString().Contains("Received Dispatch (GUILD_MEMBERS_CHUNK)") || msg.ToString().Contains("Ignored Dispatch") || msg.ToString().Contains("Received Dispatch") || msg.ToString().Contains("Connected") || msg.ToString().Contains("Heartbeat") || msg.ToString().Contains("Guild") || msg.ToString().Contains("token") || msg.ToString().Contains("GET") || msg.ToString().Contains("Hello") || msg.ToString().Contains("Identify") || msg.ToString().Contains("Event") || msg.ToString().Contains("Sending") )
                 return Task.CompletedTask;
            switch (msg.Severity)
            {
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogSeverity.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            var ms = msg.ToString();
            Console.WriteLine(msg.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            return Task.CompletedTask;
        }
        public bool Contains(string[] liste, string msg)
        {
            for (int i = 0; i < liste.Count(); i++)
                if (msg.Contains(liste[i]))
                    return true;
            return false;
        }
    }
}
