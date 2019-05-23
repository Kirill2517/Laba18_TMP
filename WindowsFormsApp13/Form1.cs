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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                try
                {
                    UserController userController = new UserController(textBox1.Text, textBox2.Text);
                    if (userController.ex)
                    {
                        InterfaceUser interfaceUser = new InterfaceUser(userController.CurrentUser);
                        interfaceUser.Show();
                        Visible = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введены неверные данные");
                }
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}