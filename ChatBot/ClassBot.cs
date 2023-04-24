/// @author Maltseva K.V.
/// Реализация чат-бота

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ChatBot
{
    public class Bot
    {
        public List<string> ChatBotHistory = new List<string>();
       //
        ///регулярные выражения..
        public static Regex regexHello = new Regex(@"Ха*й|приве*т|здарова", RegexOptions.IgnoreCase);
        public static Regex regexTime = new Regex(@"время$|час$", RegexOptions.IgnoreCase);
        public static Regex regexDate = new Regex(@"число$|дата$", RegexOptions.IgnoreCase);
        public static Regex regexHowAreYou = new Regex(@"как дела?", RegexOptions.IgnoreCase);
        public static Regex regexSum = new Regex(@"Сложи", RegexOptions.IgnoreCase);
        public static Regex regexSub = new Regex(@"Вычти", RegexOptions.IgnoreCase);
        public static Regex regexIP = new Regex(@"ip$|айпи$", RegexOptions.IgnoreCase);
        public static Regex regexInstuction = new Regex("что ты умеешь$|инструкция", RegexOptions.IgnoreCase);


        //ссылка,по которой происходит поиск айпим адреса
        string url = "https://hidemy.name/ru/what-is-my-ip/";

        //имя пользователя
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
            //WebClient класс предоставляет общие методы для отправки или 
            //    получения данных из любого локального, интрасети или 
            //    интернет - ресурса, определяемого универсальным кодом ресурса(URI).
            // создаем ссылку на объект WebClient
            using (WebClient client = new WebClient())
            {
                //задается кодировка скачиваемой страницы
                client.Encoding = System.Text.Encoding.UTF8;
                //включаем поддержку защищенного протокола(https)
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                // получаем данные страницы
                var htmlData = client.DownloadData(url);
                // и конвертим их в string, учитывая кодировку
                string htmlCode = Encoding.UTF8.GetString(htmlData);

                //с помощью регулярных выражений убираем все до вхождения подстроки 


                // type - string[] - массив строк
                //Split- делит код напополам
                var parts1 = Regex.Split(htmlCode, "<div class=ip_block><p>Ваш IP-адрес</p><div class=ip>");
                //получаем второй элемент массива(сплит по коду пробела)
                var parts2 = Regex.Split(parts1[1], " ");

                //заменяем строки по указанному регулярному выражению на пустую строку
                string numberPosition = (Regex.Replace(parts2[0], @"</div>|<form", ""));
                //  @ - заставляет понимать строку без специальных символов, т.е буквально
                return "ваш ip: " + numberPosition;
            }
        }


        ///проверка запросов для получения ответа
        public string Answer(string b)
        {
            if (regexHello.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                + this.BotSay(this.SetHelloBot());
            }
            if (regexDate.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                + this.BotSay(this.DateBot());
            }
            if (regexTime.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                + this.BotSay(this.TimeBot());
            }
            if (regexSum.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                + this.BotSay(this.BotSum(b));
            }
            if (regexSub.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                + this.BotSay(this.BotSub(b));
            }
            if(regexHowAreYou.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                 + this.BotSay(this.SetHowBot());
            }
           
            if (regexIP.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                + this.BotSay(this.SiteIP());
            }
            if (regexInstuction.IsMatch(b))
            {
                return this.UserQuest(b) + "\r"
                               + this.BotSay(this.BotInstruction());
            }


            else
            {
                return this.UserQuest(b) + "\r" + "[" + DateTime.Now.ToString("HH:mm") + "] " + "Bot Alex" + ": "
                    + "К сожалению, я не понимаю, что вы имеете ввиду(((" + "\r" + "\n";
            }
        }

        ///инструкция
        public string BotInstruction()
        {
            return "\r" + "\n" + "Я умею выполнять следующие действия: " + "\r" + "\n"
            + "Отвечать на приветствие разными вариантами " + "\r" + "\n"
            + "Отвечать на вопрос 'Как дела?'" + "\r" + "\n"
            + "Показывать дату и время " + "\r" + "\n"
            + "Складывать числа 'a и b' = c" + "\r" + "\n"
            + "Вычитать числа 'a из b' = c" + "\r" + "\n"
            + "Отследить ваш ip" + "\r" + "\n"
            + "Приятного общения)))";
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
            string[] words = quest.Split(new char[] { 'и','з' }, StringSplitOptions.RemoveEmptyEntries);
            int a = Convert.ToInt32(words[0]);
            int b = Convert.ToInt32(words[1]);
            return (-a + b).ToString();

        }
        //public void LoadHistory(string a)
        //{
        //    {
        //        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //        {
        //            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; // Фильтр для типа файлов
        //            if (openFileDialog.ShowDialog() == DialogResult.OK) // Если пользователь выбрал файл 
        //            {
        //                string text = File.ReadAllText(openFileDialog.FileName); // чтение текста из выбранного файла
        //                a = text; // загрузка текста в TextEdit
        //            }
        //        }
        //    }
        //}

        //public void SaveHistory(string a)
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для типа файлов
        //        if (saveFileDialog.ShowDialog() == DialogResult.OK) // Если пользователь выбрал файл 
        //        {
        //            string date = DateTime.Now.ToString("D");

        //            //string text = a;
        //           // ChatBotHistory.push_front($"История чата от " + date + "\r\n");
        //            ChatBotHistory.Add($"История чата от " + date + "\r\n" + a);
        //            //File.WriteAllText(saveFileDialog.FileName, all); // сохранение текста в файл по выбранному пути
        //            File.WriteAllLines(saveFileDialog.FileName, ChatBotHistory);
        //        }
        //    }
        //}
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