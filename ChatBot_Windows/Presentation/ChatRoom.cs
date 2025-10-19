using ChatBot_Windows.App;
using ChatBot_Windows.App.DTO;
using ChatBot_Windows.Presentation.Forms;

namespace ChatBot_Windows
{
    public partial class ChatRoom : Form
    {
        public ChatRoom()
        {
            InitializeComponent();
        }

        private void NewChatMenu_Click(object sender, EventArgs e)
        {
            _ = Task.Run(async () =>
            {
                var dialog = new NewChatForm();
                var dres = dialog.ShowDialog();
                while (string.IsNullOrEmpty(dialog.ChatName))
                    await Task.Delay(500);

                var details = new ChatDTO
                {
                    ChatName = dialog.ChatName,
                };

                await ChatManager.AddMewChat(dialog.ChatName);

                this.Invoke((MethodInvoker)(() => listBox1.Items.Add(dialog.ChatName)));
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1?.Items.Add("sdsdsdsd");
        }
    }
}
