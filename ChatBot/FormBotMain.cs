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
            bot.BotCheckReg(textBox_Question.Text);
            textBox_Answer.Text += bot.Answer(textBox_Question.Text, bot);
            textBox_Question.Clear();
        }

        ///справка об авторе
        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@author Maltseva K.V.");
        }
    }
}