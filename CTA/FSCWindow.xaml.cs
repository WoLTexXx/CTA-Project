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

namespace CTA
{
    /// <summary>
    /// Логика взаимодействия для FSCWindow.xaml
    /// </summary>
    public partial class FSCWindow : Window
    {
        public delegate void FSCWindowClosedDelegate();
        public event FSCWindowClosedDelegate FSCWindowClosedEvent;

        public FSCWindow()
        {
            InitializeComponent();
            if (DomainManager.GetAllADAccounts().Count > 0)
                UpdateListBoxValues();

        }

        private void btn_add_account_Click(object sender, RoutedEventArgs e)
        {
            string _login = txbx_login.Text.Trim();
            string _pass = pwbx_password.Password.Trim();
            string _domain = txbx_domain.Text.Trim();

            if (_domain != "" && _login != "" && _pass != "")
            {
                DomainManager.AddAccount(_login, _pass, _domain);
            }
            listbx_ADAccounts.Items.Clear();
            foreach (var q in DomainManager.GetAllADAccounts())
                listbx_ADAccounts.Items.Add(q);

            ClearFields();

        }

        private void btn_del_account_Click(object sender, RoutedEventArgs e)
        {
            if (listbx_ADAccounts.SelectedIndex >= 0)
                ;
            //return DialogResult = "OK";
            ClearFields();
        }
        public static void ShowMessage(string message, string caption = "Exception", MessageBoxButton messageBoxbutton = MessageBoxButton.OK,
            MessageBoxImage messageBoxImage = MessageBoxImage.Information)
        {
            MessageBox.Show(message, caption, messageBoxbutton, messageBoxImage);
        }
        private void ClearFields()
        {
            txbx_domain.Text = "";
            txbx_login.Text = "";
            pwbx_password.Password = "";
        }
        private void UpdateListBoxValues()
        {
            foreach (var q in DomainManager.GetAllADAccounts())
                listbx_ADAccounts.Items.Add(q);
        }

        private void FSCWindow_Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FSCWindowClosedEvent();
        }

    }
}
