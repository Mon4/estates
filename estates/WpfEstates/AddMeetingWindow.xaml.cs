﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using estates;

namespace WpfEstates
{
    /// <summary>
    /// Interaction logic for AddMeetingWindow.xaml
    /// </summary>
    public partial class AddMeetingWindow : Window
    {
        Meeting meeting;
        EmployeesRepository emprep;
        EstatesRepository est = EstatesRepository.ReadXML();
        ClientsRepository clients = ClientsRepository.ReadXML();
        public AddMeetingWindow()
        {
            InitializeComponent();
        }

        public AddMeetingWindow(Meeting m):this()
        {
            meeting = m;
            emprep = EmployeesRepository.ReadXML();
            EmployeeBox.ItemsSource = emprep.Employelist;
            EstatesBox.ItemsSource = est.EstateList;
            DateBox.Text = meeting.Date.ToString();
            ClientBox.ItemsSource = clients.ClientList;
            KindBox.ItemsSource = new List<string> { "Watching", "Selling" };
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            {
                int working = 1;
                meeting.Employee = emprep.FindEmployeebyToString(EmployeeBox.Text);
                meeting.Estate = est.FindEstatebyToString(EstatesBox.Text);
                try
                {
                    meeting.Date = DateTime.Parse(DateBox.Text);
                }
                catch(FormatException)
                {
                    working = 0;
                    ExceptionLabelMeeting.Content = "Wrong date format!";
                }
                //DateTime.TryParseExact(DateBox.Text, new[] { "yyyy-MM-dd HH:mm", "yyyy/MM/dd HH:mm", "MM/dd/yy HH:mm", "dd-MM-yyyy HH:mm", "dd.MM.yyyy HH:mm",
                //"dd-MMM-yy HH:mm", "dd-MMM-yyyy HH:mm","dd.MMM.yyyy HH:mm" }, null, DateTimeStyles.None, out DateTime date);
                //meeting.Date = date;
                meeting.Client = clients.FindClientbyToString(ClientBox.Text);
                if (KindBox.Text == "Watching")
                {
                    meeting.KindOfMeeting = KindOfMeeting.watching;
                }
                else
                {
                    meeting.KindOfMeeting = KindOfMeeting.selling;
                }
                if(DateBox.Text=="" | EmployeeBox.SelectedIndex==-1 | EstatesBox.SelectedIndex==-1 | 
                    ClientBox.SelectedIndex==-1 | KindBox.SelectedIndex==-1)
                {
                    working = 0;
                    ExceptionLabelMeeting.Content = "Some fields are empty!";
                }
                if (working == 1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }
    }
}
