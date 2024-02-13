using System;
using System.Windows;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Data.SqlClient;
using Avalonia.Threading;
using Avalonia.Dialogs;
using AvaloniaGenerics.Dialogs;
using MySql.Data.MySqlClient;
using Avalonia.VisualTree;

namespace Санёк
{
    public partial class MainWindow : Window
    {
        private string connStr = "server=localhost;database=taxi;port=3306;User Id=root;password=05042005";
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (AuthenticateUser(login, password))
            {
                // Пользователь успешно аутентифицирован
                Main1 main1 = new Main1();
                main1.Show();
                this.Close();
            }
            else
            {
                loginTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool AuthenticateUser(string login, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM authorization WHERE Login = @Login AND password = @Password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                Int64 count = (Int64)command.ExecuteScalar();

                return count > 0;
            }
        }
    }
}