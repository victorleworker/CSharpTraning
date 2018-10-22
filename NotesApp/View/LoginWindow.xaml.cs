﻿using NotesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesApp.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginVM viewModel;
        NotesWindow NotesWindow;
        public LoginWindow(NotesWindow nw)
        {
            InitializeComponent();
            NotesWindow = nw;
            viewModel = this.Resources["login"] as LoginVM;
            //LoginVM vm = new LoginVM();
            containerGrid.DataContext = viewModel;
            viewModel.HasLoginedIn += Vm_HasLoggedIn;

        }

        private void Vm_HasLoggedIn(object sender, EventArgs e)
        {
            NotesWindow.Show();
            this.Close();
        }

        private void haveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            registerStackPanel.Visibility = Visibility.Collapsed;
            loginStackPanel.Visibility = Visibility.Visible;
        }

        private void noAccountButton_Click(object sender, RoutedEventArgs e)
        {
            registerStackPanel.Visibility = Visibility.Visible; 
            loginStackPanel.Visibility = Visibility.Collapsed;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(App.Userid))
            {
                Application.Current.Shutdown();
            }                       
        }
    }
}
