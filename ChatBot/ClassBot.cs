/// @author Maltseva K.V.
/// Реализация чат-бота

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot
{
    public class Bot
    {
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

        ///вывод запросов пользователя и ответов бота 
        public string BotSay(string bot)
        {
            return "[" + DateTime.Now.ToString("HH:mm") + "] " + "Bot Alex" + ": " + bot + "\r" + "\n";
        }

        public string UserQuest(string quest)
        {
            return "[" + DateTime.Now.ToString("HH:mm") + "] " + FormLogin.userName + ": " + quest  + "\r" + "\n";
        }

       

  
        string userName = FormLogin.userName;

        Random rand = new Random();
        ///привет от бота
        public string SetHelloBot()
        {
           // Random rand = new Random();
            string[] mas = { "Привет", "Дароу","Хай", "Рад видеть","Nice to meet you"};
            int mas1 = rand.Next(mas.Length);

            return mas[mas1] + " " + userName;
        }
        ///ответ на вопрос - как дела
        public string SetHowBot()
        {
            //Random rand = new Random();
            string[] mas = { "OK","Прекрасно","Отлично" };
            int mas1 = rand.Next(mas.Length);

            return mas[mas1];
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
            quest = quest.Substring(quest.LastIndexOf('ж') + 2); /// Как тут можно сделать по другому что бы не отслеживать ласт символ
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
