using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterApiService.Common
{
    public class DiscordSendMessages
    {
        private static DiscordSocketClient _client = new DiscordSocketClient();

        
        public static bool IsStarted {get;set;} = false;
        public static async void DiscordSettingsAsync()
        {
            _client.Log += LogAsync;
            _client.MessageReceived += OnMessageReceivedAsync;
            _client.Ready += ReadyAsync;

            await _client.LoginAsync(TokenType.Bot, CommonParameter.DiscordToken);
            await _client.StartAsync();
            await _client.SetStatusAsync(UserStatus.Online);
            
            await Task.Delay(-1);
        }

        private static Task OnMessageReceivedAsync(SocketMessage message)
        {
            Console.WriteLine(message.Content + " from " + message.Author.Username);
            return Task.CompletedTask;
        }

        private static Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

        private static Task ReadyAsync()
        {
            SocketGuild _guild;
            Console.WriteLine("Bot is connected and ready.");
            try
            {
                _guild = _client.Guilds.First(g => g.Name == "しろろんのサーバー");
                IsStarted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding server: " + ex.Message);
            }
            return Task.CompletedTask;
        }

        public static async Task SendMessageAsync(string channelId, string message)
        {
            try
            {
                var channel = _client.GetChannel(ulong.Parse(channelId)) as IMessageChannel;
                if(channel != null){
                    await channel.SendMessageAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending message: " + ex.Message);
            }
        }
    }
}
