using System;
using System.Windows.Forms;
using WindowsFormsApp12;
namespace WindowsFormsApp13
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (loginTextBox.Text != string.Empty && passwordTextBox.Text != string.Empty && nameTextBox.Text != string.Empty)
            {
                int age;
                if (ageTextBox.Text != string.Empty) { age = Convert.ToInt32(ageTextBox.Text); }
                else age = 0;
                UserController userController = new UserController(loginTextBox.Text, nameTextBox.Text,
                     passwordTextBox.Text, age);

                if (userController.IsNewUser)
                {
                    userController.SetNewUserData(passwordTextBox.Text,
                        nameTextBox.Text, age);
                    MessageBox.Show("Пользователь успешно создан");
                    this.Close();
                }
                else
                    MessageBox.Show("Пользователь уже существует, выберите другой логин");
            }
            else MessageBox.Show("Введите обязательные поля (логин, имя, пароль)");
        }

        private void AgeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
