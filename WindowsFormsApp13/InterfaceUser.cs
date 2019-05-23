using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp12;
namespace WindowsFormsApp13
{
    public partial class InterfaceUser : Form
    {
        public InterfaceUser(User CurrentUser)
        {
            InitializeComponent();
            label1.Text = CurrentUser.Name;
            if(CurrentUser.Age != 0)
                label2.Text = CurrentUser.Age.ToString();
        }

        private void InterfaceUser_Load(object sender, EventArgs e)
        {
        }

        private void InterfaceUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
