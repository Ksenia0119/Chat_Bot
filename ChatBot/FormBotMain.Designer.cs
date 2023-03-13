
/// @author Maltseva K.V.
/// Реализация чат-бота
namespace ChatBot
{
    partial class FormBot
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Answer = new System.Windows.Forms.TextBox();
            this.textBox_Question = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_author = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Answer
            // 
            this.textBox_Answer.Location = new System.Drawing.Point(67, 30);
            this.textBox_Answer.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Answer.Multiline = true;
            this.textBox_Answer.Name = "textBox_Answer";
            this.textBox_Answer.ReadOnly = true;
            this.textBox_Answer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Answer.Size = new System.Drawing.Size(581, 228);
            this.textBox_Answer.TabIndex = 0;
            this.textBox_Answer.TabStop = false;
            // 
            // textBox_Question
            // 
            this.textBox_Question.Location = new System.Drawing.Point(81, 292);
            this.textBox_Question.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Question.Name = "textBox_Question";
            this.textBox_Question.Size = new System.Drawing.Size(395, 22);
            this.textBox_Question.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.AutoSize = true;
            this.button_Send.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Send.BackgroundImage = global::ChatBot.Properties.Resources.image_send;
            this.button_Send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Send.Font = new System.Drawing.Font("Gabriola", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Send.Location = new System.Drawing.Point(497, 271);
            this.button_Send.Margin = new System.Windows.Forms.Padding(4);
            this.button_Send.Name = "button_Send";
            this.button_Send.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.button_Send.Size = new System.Drawing.Size(93, 61);
            this.button_Send.TabIndex = 2;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(703, 28);
            this.menuStrip_main.TabIndex = 3;
            this.menuStrip_main.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_author});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // ToolStripMenuItem_author
            // 
            this.ToolStripMenuItem_author.Name = "ToolStripMenuItem_author";
            this.ToolStripMenuItem_author.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_author.Text = "Об авторе";
            this.ToolStripMenuItem_author.Click += new System.EventHandler(this.обАвтореToolStripMenuItem_Click);
            // 
            // FormBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 375);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Question);
            this.Controls.Add(this.textBox_Answer);
            this.Controls.Add(this.menuStrip_main);
            this.MainMenuStrip = this.menuStrip_main;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBot";
            this.Text = "Чат";
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Answer;
        private System.Windows.Forms.TextBox textBox_Question;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_author;
    }
}

