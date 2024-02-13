using System.Collections.Generic;
using Avalonia.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Avalonia.Interactivity;
using System.Linq;
using Avalonia.Markup.Xaml;
using System.Windows;
using Avalonia.Collections;


namespace Санёк;

public partial class TaxiDriver : Window
{
    // строка подключения к базе данных
    private string _connString = "server=localhost;database=taxi;port=3306;User Id=root;password=05042005";
    
    
    private void LoadLeaveRequests()// метод для загрузки данных
    {
        using (MySqlConnection conn = new MySqlConnection(_connString))// создаем соединение
        {
            conn.Open(); // открываем соединение
                                                        
            string query = "SELECT * FROM taxidriver";// формируем SQL-запрос
            MySqlCommand cmd = new MySqlCommand(query, conn); //создаем команду

            using (MySqlDataReader reader = cmd.ExecuteReader())// выполняем запрос
            {
                List<TaxiDriver1> leaveRequests = new List<TaxiDriver1>();// создаем список для хранения данных

                while (reader.Read())// читаем данные
                {
                    TaxiDriver1 leaveRequest = new TaxiDriver1();// создаем объект
                    leaveRequest.TaxiDriverID = reader.GetInt32("TaxiDriverID");
                    leaveRequest.CarID = reader.GetString("CarID");
                    leaveRequest.DriverID = reader.GetString("DriverID");

                    leaveRequests.Add(leaveRequest);// добавляем объект в список
                }

                leaveRequestsGrid.ItemsSource = leaveRequests;// устанавливаем источник данных
            }
        }
    }
    private void AddLeaveRequest()// метод для добавления записи
    {
        int carId = int.Parse(txtEmployeeId.Text);// получаем данные
        string name = datePickerStartDate.Text;// получаем данные
        string number = datePickerEndDate.Text;// получаем данные

        using (MySqlConnection conn = new MySqlConnection(_connString))// создаем соединение
        {
            conn.Open();// открываем соединение

            string query = "INSERT INTO Car (CarID, Name, Number) VALUES (@CarID, @Name, @Number)";// формируем SQL-запрос
            MySqlCommand cmd = new MySqlCommand(query, conn);// создаем команду
            cmd.Parameters.AddWithValue("@CarID", carId);// добавляем параметры
            cmd.Parameters.AddWithValue("@Name", name);// добавляем параметры
            cmd.Parameters.AddWithValue("@Number", number);// добавляем параметры
            

            cmd.ExecuteNonQuery();// выполняем запрос
        }

        LoadLeaveRequests();// обновляем данные
        txtEmployeeId.Text = "";
        datePickerStartDate.Text = "";
        datePickerEndDate.Text = "";
    }

    private void btnFilter_Click(object sender, RoutedEventArgs e)
    {
        using (MySqlConnection conn = new MySqlConnection(_connString))// создаем соединение
        {
            conn.Open(); // открываем соединение
                                                        
            string query = "SELECT * FROM car where Name LIKE '%Lada%'";// формируем SQL-запрос
            MySqlCommand cmd = new MySqlCommand(query, conn); //создаем команду

            using (MySqlDataReader reader = cmd.ExecuteReader())// выполняем запрос
            {
                List<Car1> leaveRequests = new List<Car1>();// создаем список для хранения данных

                while (reader.Read())// читаем данные
                {
                    Car1 leaveRequest = new Car1();// создаем объект
                    leaveRequest.CarID = reader.GetInt32("CarID");
                    leaveRequest.Name = reader.GetString("Name");
                    leaveRequest.Number = reader.GetString("Number");

                    leaveRequests.Add(leaveRequest);// добавляем объект в список
                }

                leaveRequestsGrid.ItemsSource = leaveRequests;// устанавливаем источник данных
            }
        }
    }

    private void btnBack_Click(object sender, RoutedEventArgs e)
    {
        Main1 main1 = new Main1();
        main1.Show();
        this.Close();
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
        using (MySqlConnection conn = new MySqlConnection(_connString))// создаем соединение
        {
            conn.Open(); // открываем соединение
                                                        
            string query = "SELECT * FROM car WHERE Name LIKE '%" + txtSearch.Text + "%'";// формируем SQL-запрос
            MySqlCommand cmd = new MySqlCommand(query, conn); //создаем команду

            using (MySqlDataReader reader = cmd.ExecuteReader())// выполняем запрос
            {
                List<Car1> leaveRequests = new List<Car1>();// создаем список для хранения данных

                while (reader.Read())// читаем данные
                {
                    Car1 leaveRequest = new Car1();// создаем объект
                    leaveRequest.CarID = reader.GetInt32("CarID");
                    leaveRequest.Name = reader.GetString("Name");
                    leaveRequest.Number = reader.GetString("Number");

                    leaveRequests.Add(leaveRequest);// добавляем объект в список
                }

                leaveRequestsGrid.ItemsSource = leaveRequests;// устанавливаем источник данных
            }
        }
    }
    private void btnDelete_Click(object sender, RoutedEventArgs e)// метод для удаления записи
    {
        int carid = int.Parse(txtEmployeeId.Text);// получаем данные
        
        using (MySqlConnection conn = new MySqlConnection(_connString))// создаем соединение
        {
            conn.Open();// открываем соединение

            // Создание SQL-запроса для удаления записи по идентификатору работника
            string query = "DELETE FROM car WHERE CarID = @CarID";// формируем SQL-запрос
            MySqlCommand cmd = new MySqlCommand(query, conn);// создаем команду
            cmd.Parameters.AddWithValue("@CarID", carid);// добавляем параметры

            // Выполнение SQL-запроса
            int rowsAffected = cmd.ExecuteNonQuery();// выполняем запрос
            LoadLeaveRequests();// обновляем данные
        }
    }
  

    private void btnAdd_Click(object sender, RoutedEventArgs e)// метод для добавления записи
    {
        AddLeaveRequest();// вызываем метод
    }
    
    
    public TaxiDriver()
    {
        InitializeComponent();
        LoadLeaveRequests();// вызываем метод при загрузке формы
    }
}