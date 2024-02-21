using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birthdays
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TodayBirthdays today = new TodayBirthdays();
            today.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addUser addFriend = new addUser();
            addFriend.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeUser changeFriend = new changeUser();
            changeFriend.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FriendList friendList = new FriendList();   
            friendList.Show();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
