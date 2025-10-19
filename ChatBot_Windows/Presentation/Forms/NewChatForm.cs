using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot_Windows.Presentation.Forms
{
    public partial class NewChatForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ChatName { get; set; }
        public NewChatForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChatName = textBox1.Text;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
