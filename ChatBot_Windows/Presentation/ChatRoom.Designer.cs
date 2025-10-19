namespace ChatBot_Windows
{
    partial class ChatRoom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            NewChatMenu = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            listBox1 = new ListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { NewChatMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(725, 25);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // NewChatMenu
            // 
            NewChatMenu.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewChatMenu.ForeColor = Color.Maroon;
            NewChatMenu.Name = "NewChatMenu";
            NewChatMenu.Size = new Size(75, 21);
            NewChatMenu.Text = "چت جدید";
            NewChatMenu.Click += NewChatMenu_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(278, 485);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(359, 96);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(645, 485);
            button1.Name = "button1";
            button1.Size = new Size(68, 97);
            button1.TabIndex = 3;
            button1.Text = "ارسال پیام جدید";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.AntiqueWhite;
            richTextBox2.Location = new Point(278, 27);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(435, 452);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(11, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(261, 544);
            listBox1.TabIndex = 5;
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 587);
            Controls.Add(listBox1);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ChatRoom";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem NewChatMenu;
        private RichTextBox richTextBox1;
        private Button button1;
        private RichTextBox richTextBox2;
        private ListBox listBox1;
    }
}
