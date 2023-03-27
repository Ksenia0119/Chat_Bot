/// @author Maltseva K.V.
/// Реализация чат-бота

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot
{
    public class Bot
    {

        ///регулярные выражения
        public static Regex regexHello = new Regex(@"Ха*й|приве*т|здарова", RegexOptions.IgnoreCase);
        public static Regex regexTime = new Regex(@"время$|час$", RegexOptions.IgnoreCase);
        public static Regex regexDate = new Regex(@"число$|дата$", RegexOptions.IgnoreCase);
        public static Regex regexHowAreYou = new Regex(@"как дела?", RegexOptions.IgnoreCase);
        public static Regex regexSum = new Regex(@"Сложи", RegexOptions.IgnoreCase);
        public static Regex regexSub = new Regex(@"Вычти", RegexOptions.IgnoreCase);
        public static Regex regexIP = new Regex(@"ip$|айпи$", RegexOptions.IgnoreCase);

        string url = "https://hidemy.name/ru/what-is-my-ip/";


        string userName = FormLogin.userName;

        ///вывод запросов пользователя и ответов бота 
        public string BotSay(string bot)
        {
            return "[" + DateTime.Now.ToString("HH:mm") + "] " + "Bot Alex" + ": " + bot + "\r" + "\n";
        }

        public string UserQuest(string quest)
        {
            return "[" + DateTime.Now.ToString("HH:mm") + "] " + FormLogin.userName + ": " + quest + "\r" + "\n";
        }

        Random rand = new Random();

        ///привет от бота
        public string SetHelloBot()
        {
            // Random rand = new Random();
            string[] mas = { "Привет", "Дароу", "Хай", "Рад видеть", "Nice to meet you" };
            int mas1 = rand.Next(mas.Length);

            return mas[mas1] + " " + userName;
        }
        ///ответ на вопрос - как дела
        public string SetHowBot()
        {
            //Random rand = new Random();
            string[] mas = { "OK", "Прекрасно", "Отлично" };
            int mas1 = rand.Next(mas.Length);

            return mas[mas1];


        }

        ///получение ip 
        /// https://upread.ru/art.php?id=84
        public string SiteIP()
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var htmlData = client.DownloadData(url);
                string htmlCode = Encoding.UTF8.GetString(htmlData);

                var parts1 = Regex.Split(htmlCode, "<div class=ip_block><p>Ваш IP-адрес</p><div class=ip>");
                var parts2 = Regex.Split(parts1[1], " ");
                string numberPosition = (Regex.Replace(parts2[0], @"</div>|<form", ""));
                return "ваш ip: " + numberPosition;
            }
        }



        ///проверка запросов для получения ответа
        public string Answer(string b, Bot bot)
        {
            if (regexHello.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                + bot.BotSay(bot.SetHelloBot());
            }
            if (regexDate.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                + bot.BotSay(bot.DateBot());
            }
            if (regexTime.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                + bot.BotSay(bot.TimeBot());
            }
            if (regexSum.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                + bot.BotSay(bot.BotSum(b));
            }
            if (regexSub.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                + bot.BotSay(bot.BotSub(b));
            }
            if(regexHowAreYou.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                 + bot.BotSay(bot.SetHowBot());
            }
           
            if (regexIP.IsMatch(b))
            {
                return bot.UserQuest(b) + "\r"
                + bot.BotSay(bot.SiteIP());
            }

            else
            {
                return bot.UserQuest(b) + "\r" + "[" + DateTime.Now.ToString("HH:mm") + "] " + "Bot Alex" + ": "
                    + "К сожалению, я не понимаю, что вы имеете ввиду(((" + "\r" + "\n";
            }
        }


      
        ///запрос время
        public string TimeBot()
        {
            return DateTime.Now.ToString("T");
        }
        ///запрос дата
        public string DateBot()
        {
            return DateTime.Now.ToString("D");
        }


        ///запрос сложение
        public string BotSum(string quest)
        {

            quest = quest.Replace(" ", "");
            quest = quest.Substring(quest.LastIndexOf('ж') + 2); 
            string[] words = quest.Split(new char[] { 'и' }, StringSplitOptions.RemoveEmptyEntries);
            int a = Convert.ToInt32(words[0]);
            int b = Convert.ToInt32(words[1]);
            return (a + b).ToString();

        }
        /// запрос вычитание
        public string BotSub(string quest)
        {
            quest = quest.Replace(" ", "");
            quest = quest.Substring(quest.LastIndexOf('т') + 2);
            string[] words = quest.Split(new char[] { 'и' }, StringSplitOptions.RemoveEmptyEntries);
            int a = Convert.ToInt32(words[0]);
            int b = Convert.ToInt32(words[1]);
            return (a - b).ToString();

        }
    }
}

//Bot bot;

//public void ChekReg(string Ch,string n,Bot bot)
//{
//    //bot.Question(Convert.ToString(textBox_Question.Text));
//    if (regexHello.IsMatch(n))
//    {
//        Ch += bot.UserQuest(n);
//        //textBox_Result.Text += "[" + DateTime.Now.ToString("HH:mm") + "] " + FormLogin.userName + ": " + textBox_Question.Text + "\r" + "\n";
//        Ch+= bot.BotSay(bot.SetHelloBot());

//        // textBox_Result.Text += "[" + DateTime.Now.ToString("HH:mm") + "] " + "Бот" + ": " + bot.SetHelloBot() +  "\r" + "\n";
//        //textBox_Question.Clear();
//    }
//    if (regexTime.IsMatch(n))
//    {
//       Ch += bot.UserQuest(n);
//        //textBox_Result.Text += "[" + DateTime.Now.ToString("HH:mm") + "] " + FormLogin.userName + ": " + textBox_Question.Text + "\r" + "\n";
//       Ch += bot.BotSay(bot.TimeBot());

//        //textBox_Result.Text += "[" + DateTime.Now.ToString("HH:mm") + "] " + "Бот" + ": " + bot.TimeBot() + "\r" + "\n";
//    }
//    if (regexDate.IsMatch(n))
//    {
//       Ch += bot.UserQuest(n);
//        //textBox_Result.Text += "[" + DateTime.Now.ToString("HH:mm") + "] " + FormLogin.userName + ": " + textBox_Question.Text + "\r" + "\n";
//       Ch += bot.BotSay(bot.DateBot());

//        //textBox_Result.Text += "[" + DateTime.Now.ToString("HH:mm") + "] " + "Бот" + ": " + bot.DateBot() + "\r" + "\n";
//    }
//    if (regexSum.IsMatch(n))
//    {
//       Ch += bot.UserQuest(n);
//        Ch += bot.BotSay(bot.BotSum(n));
//    }
//  бб  if (regexSub.IsMatch(n))
//    {
//       Ch += bot.UserQuest(n);
//        Ch += bot.BotSay(bot.BotSub(n));
//    }


//....}

////public void BotCheckReg(string a)
////{
////    if (regexHello.IsMatch(a))
////    {
////        Answer(a, this);
////    }
////}