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


namespace Санёк;

public partial class Main1 : Window
{
    public Main1()
    {
        InitializeComponent();
    }
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        Car carForm = new Car();
        carForm.Show();
        this.Close();
    }
    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        Driver Driver = new Driver();
        Driver.Show();
        this.Close();
    }
    private void Button3_Click(object sender, RoutedEventArgs e)
    {
        TaxiDriver TaxiDriver  = new TaxiDriver ();
        TaxiDriver .Show();
        this.Close();
    }
    private void Button4_Click(object sender, RoutedEventArgs e)
    {
        Bill Bill  = new Bill  ();
        Bill  .Show();
        this.Close();
    }
    private void Button5_Click(object sender, RoutedEventArgs e)
    {
        Venue venue = new Venue ();
        venue.Show();
        this.Close();
    }
    private void Button6_Click(object sender, RoutedEventArgs e)
    {
        Client client = new Client ();
        client.Show();
        this.Close();
    }
    private void Button7_Click(object sender, RoutedEventArgs e)
    {
        Order order = new Order ();
        order.Show();
        this.Close();
    }
}