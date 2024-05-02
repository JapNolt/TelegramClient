namespace TelegramClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new WTelegram.Client();
            var myself = await client.LoginUserIfNeeded();
            Console.WriteLine($"We are logged-in as {myself} (id {myself.id})");

            var chats = await client.Messages_GetAllChats();
            Console.WriteLine("This user has joined the following:");
            foreach (var (id, chat) in chats.chats)
                if (chat.IsActive)
                    Console.WriteLine($"{id,10}: {chat.ToString()}");
        }
    }
}
