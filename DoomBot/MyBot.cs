using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DoomBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] pastas;
        string[] patricks;

        public MyBot()
        {

            pastas = new string[]
            {
                "I looked at this card originally, and I thought, you know, it’s a card, and you play this card. The card will be that card that you’ve played, so you’re playing a card. So it is one thing to play a card if your opponent doesn’t really have any cards. The card will screw up the card pretty hard, and that means it’s a pretty good card.",
                "Here we can observe the Twitch Memer in his natural habitat, stuck as usual in this intricate limbo of carefully crafted memes, emote spam and endless copypastas that no one even bothers to read anymore. The Memer actually used to be a very functional human being way back then. Will he ever claim that state back and finally manage to reproduce?",
                "Everyday my dad worked hard to feed us. My mom left us and my dad supported me on his own. We were doing well until my dad didn't come back from work today. Some asshole blew up the giant robotic dog he worked in and he died.",
                "When I'm ready to go to sleep I grab my laptop and get in bed. I open my laptop, go to Kripps youtube, turn the brightness all the way up and watch the video with the laptop screen close to my eyes. When the video is done I close my eyes and can still see Kripps face while I go to sleep. It's the only way I can feel safe.",
                "Guys can you please not spam the chat. My mom bought me this new laptop and it gets really hot when the chat is being spamed. Now my leg is starting to hurt because it is getting so hot. Please, if you don't want me to get burned, then dont spam the chat",
                "Guys, please don't spam. My daughter made a macaroni dinosaur in school and it passes its days pasted to my laptop screen. When too many messages show up it starts turning into a nacho cheese torpedo. God bless, thanks for understanding.",
                "hi ich name is Igor, evry day i woke up at 3:30am and must go fed my neihgboaur rats just to go and watched your streamerino on his 25 kg sagem laptop. thanks to you i can carri myself from bronze V to unranked, im think im the very happier person in world, i wisch you long life my freund. Sorry for baddest englando, pls no copy pasterino frappuchino potatoni dongerini challengeroni my story",
                "TᕼIᔕ ᗰᕮᔕᔕᗩGᕮ Iᔕ ᑭᖇOTᕮᑕTᕮᗪ ᗷY ᗩ ᔕᑭᕮᑕIᗩᒪ ᖴOᑎT. IT'ᔕ IᗰᑭOᔕᔕIᗷᒪᕮ TO ᑕOᑭY IT. TᖇY ᗩᑎᗪ YOᑌ ᗯIᒪᒪ ᖴᗩIᒪ",
                "You notice a wall of text in twitch chat and your hand instinctively goes to the mouse. You scroll up to stop the chat elevator and read the pasta, indulging in its delights... You soon realize that this pasta conveys no information nor is particularly witty or funny. Nevertheless, you drag your mouse across, hit Ctrl+C, then Ctrl+V and press Enter",
                "When jon lenon was 10 his teacher askd 'what do u wana do when u are adult ? ' and jon lenon said 'hapy'. the teacher said 'u didn't understand question' and lenon said 'u dont understand life.'. The teacher was alber Einstein, retweet if u beliv in god.",
                "Fresh pasta was traditionally produced by hand, sometimes with the aid of simple machines, but today many varieties of fresh pasta are also commercially produced by large-scale machines, and the products are widely available in supermarkets.",
                "tfw you have so much autism that you spam the same sentence 50 times in one message over and over again and you don't realize that you're not funny because you're so autistic FeelsBadMan",
                "Alright, listen up motherfuckers. You think you're fucking funny spamming your shitty pasta and emotes. Well if you fucking dare copy and paste this message, I will literally come over to your house and knock you the fuck out. Is that understood?",
                "Lɪsᴛᴇɴ ᴅᴜᴅᴇ, I'ᴠᴇ ʙᴇᴇɴ ᴍᴀᴋɪɴɢ ᴍᴇᴍᴇs sɪɴᴄᴇ I ᴡᴀs 11, ɪʀᴏɴɪᴄᴀʟʟʏ ᴍᴇᴍᴇɪɴɢ sɪɴᴄᴇ I ᴡᴀs 17, ᴀɴᴅ ᴀɴᴛɪ-ɪʀᴏɴɪᴄᴀʟʟʏ ᴀɴᴛɪ-ᴍᴇᴍᴇɪɴɢ sɪɴᴄᴇ ɪ ᴡᴀs 20. Iᴠᴇ ᴄʟᴇᴀʀʟʏ ʙᴇᴇɴ ᴀʜᴇᴀᴅ ᴏғ ᴛʜᴇ ᴍᴇᴍᴇʀɪɴᴏ ᴍᴇᴛᴀᴄʜɪɴᴏ ғᴏʀ ᴀ ɢᴏᴏᴅ 6 ʏᴇᴀʀs ɴᴏᴡ. Gᴇᴛ ᴀ ɢʀɪᴘ ᴜ ғᴜᴄᴋɪɴ ɴᴇʀᴅ",
                "(◕‿◕✿) Dear Person in the chat, you are beautiful. Whatever is going on in your life right now, please know that you matter and your story is important. You are loved (◕‿◕✿)"
            };

            patricks = new string[]
            {
                "pics/p2.png",
                "pics/p3.jpg",
                "pics/p4.gif",
                "pics/p5.png",
                "pics/p6.jpg",
                "pics/p7.gif",
                "pics/p8.jpg",
                "pics/pat.jpg"
            };

            rand = new Random();

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterRampageCommand();

            /*commands.CreateCommand("1")
                .Do(async (e) =>
                {
                    for (;;)
                    {
                        await e.Channel.SendMessage(Console.ReadLine());
                    }
                });*/

            commands.CreateCommand("bum")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("no, u");
                });

            commands.CreateCommand("boosted")
                .Do(async (e) =>
                {
                    //await e.Channel.SendMessage("no, u");
                    await e.Channel.SendTTSMessage("You are a boosted animal.");
                });

            commands.CreateCommand("burn")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("YEEEEOUCHHHHHHH");
                });

            commands.CreateCommand("commands")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("!bum\n!rampage\n!pasta\n!airhorn\n!burn\n!boosted\n!doggo");
                });

            commands.CreateCommand("pasta")
                .Do(async (e) =>
                {
                    int randomIndex = rand.Next(pastas.Length);
                    string message = pastas[randomIndex];
                    await e.Channel.SendMessage(message);
                });

            commands.CreateCommand("doggo")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=t_Pt7z6qq5k");
                });

            commands.CreateCommand("airhorn")
                .Do(async (e) =>
                {
                    int randomIndex = rand.Next(patricks.Length);
                    string file = patricks[randomIndex];
                    await e.Channel.SendFile(file);
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzA5MTM0NTE2MDU0Nzg2MDQ4.C-rAbQ.PNnt6i61jGmj27X5Ea9zqwxmhLs", TokenType.Bot);
                discord.SetGame("52");
            });
        }

        private void RegisterRampageCommand()
        {
            commands.CreateCommand("rampage")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("pics/maxresdefault.jpg");
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
