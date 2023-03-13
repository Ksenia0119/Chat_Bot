/// @author Maltseva K.V.
/// Реализация чат-бота


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class FormBot : Form
    {
        public Bot bot = new Bot();
        ///регулярные выражения
        public static Regex regexHello = new Regex(@"Ха*й|приве*т|здарова", RegexOptions.IgnoreCase);
        public static Regex regexTime = new Regex(@"время$|час$", RegexOptions.IgnoreCase);
        public static Regex regexDate = new Regex(@"число$|дата$", RegexOptions.IgnoreCase);
        public static Regex regexHowAreYou = new Regex(@"как дела?", RegexOptions.IgnoreCase);
        public static Regex regexSum = new Regex(@"Сложи", RegexOptions.IgnoreCase);
        public static Regex regexSub = new Regex(@"Вычти", RegexOptions.IgnoreCase);

        
        public FormBot()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.image_back;
            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FormBot_KeyEnter);
           
            
        }
        ///Горячая клавиша enter
        private void FormBot_KeyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send.PerformClick();
            }
        }
        ///отправить запрос
        private void button_Send_Click(object sender, EventArgs e)
        {
          
            if (regexHello.IsMatch(textBox_Question.Text))
            {
                textBox_Answer.Text += bot.UserQuest(textBox_Question.Text);
               
                textBox_Answer.Text += bot.BotSay(bot.SetHelloBot());

                
            }
            if (regexTime.IsMatch(textBox_Question.Text))
            {
                textBox_Answer.Text += bot.UserQuest(textBox_Question.Text);
                
                textBox_Answer.Text += bot.BotSay(bot.TimeBot());

            }
            if (regexDate.IsMatch(textBox_Question.Text))
            {
                textBox_Answer.Text += bot.UserQuest(textBox_Question.Text);
                
                textBox_Answer.Text += bot.BotSay(bot.DateBot());

            }
            if (regexSum.IsMatch(textBox_Question.Text))
            {
                textBox_Answer.Text += bot.UserQuest(textBox_Question.Text);
                textBox_Answer.Text += bot.BotSay(bot.BotSum(textBox_Question.Text));
            }
            if (regexSub.IsMatch(textBox_Question.Text))
            {
                textBox_Answer.Text += bot.UserQuest(textBox_Question.Text);
                textBox_Answer.Text += bot.BotSay(bot.BotSub(textBox_Question.Text));
            }
            if (regexHowAreYou.IsMatch(textBox_Question.Text))
            {
                textBox_Answer.Text += bot.UserQuest(textBox_Question.Text);

                textBox_Answer.Text += bot.BotSay(bot.SetHowBot());
            }
            //bot.ChekReg(textBox_Result.Text, textBox_Question.Text,bot);
            textBox_Question.Clear();


        }
        ///справка об авторе
        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@author Maltseva K.V.");
        }
    }
}
