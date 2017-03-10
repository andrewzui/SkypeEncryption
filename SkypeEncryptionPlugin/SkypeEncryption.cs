using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;

namespace SkypeEncryptionPlugin
{
    public partial class SkypeEncryption : Form
    {
        Skype skype = new Skype();
        List<User> friends;
        public SkypeEncryption()
        {
            skype.Attach(7, true);
            friends = new List<User>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (User u in skype.Friends)
            {
                friends.Add(u);
                if (!u.Handle.Contains("+"))
                {
                    comboBox1.Items.Add(u.FullName);
                }
                
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void myKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void foreignPublicKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 50;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string history = "";
            var user = (from u in friends
                        where (u.FullName.Contains((string)comboBox1.SelectedItem))
                        select u).FirstOrDefault();
            SKYPE4COMLib.IChatMessageCollection mc = skype.Messages;
            foreach (IChatMessage msg in mc)
            {
                if (msg.FromHandle == user.Handle)
                {
                    history += msg.Sender.FullName + ": " + "\n" + msg.Body + " \n" + msg.Timestamp + "\n";
                }
            }
            richTextBox2.Text = history;
        }
    }
}
