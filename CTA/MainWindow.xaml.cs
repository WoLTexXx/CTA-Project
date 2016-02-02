using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace CTA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string domain;
        private string username;
        private string password;
        private PrincipalContext pcx;
        private DirectoryEntry de;
        private List<int> allPC;
        private List<int> freePC;
        private SolidColorBrush _brush;
        private string currentBranch;
        private string currentPC;
        delegate void DELEG();
        event DELEG ConnectionSuccess;
        event DELEG ConnectionClose;

        public MainWindow()
        {
            InitializeComponent();

            try
            {

                bool xz = GetFrameWorkVersion();
                if (!xz)
                {
                    MessageBox.Show("For correct working of the application, in your operation system must be install .NET FrameWork 4.5 or higher!",
                        "Please install .NET FrameWork 4.5 or higher", MessageBoxButton.OK, MessageBoxImage.Stop);
                    this.Close();
                }

                txb_username.Text = Environment.UserName;
                pbx_password.PasswordChar = '*';
                pbx_password.Password = "";
                lbl_freePC.Content = "MOS-?";
                currentBranch = null;
                currentPC = null;
                domain = Environment.UserDomainName;

                btn_search.IsEnabled = false;
                btn_createPC.IsEnabled = false;
                cmbx_StartIndex.IsEnabled = false;

                _brush = new SolidColorBrush(Colors.Red);
                btn_connect.Background = _brush;

                lbl_info.Content = "Information: Please, input Login and Password!";

                ConnectionSuccess += MainWindow_ConnectionSuccess;
                ConnectionClose += MainWindow_ConnectionClose;

                ConnectionClose();

                if (domain == "BIN")
                    OULoader(new DirectoryEntry("LDAP://ou=bin branches,dc=bin,dc=bank"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void MainWindow_ConnectionClose()
        {
            btn_search.IsEnabled = false;
            btn_createPC.IsEnabled = false;
            cmbx_StartIndex.IsEnabled = false;

            txb_username.IsEnabled = true;
            pbx_password.IsEnabled = true;
            cmbx_domain.IsEnabled = true;
            btn_connect.IsEnabled = true;

            pbx_password.Password = "";
        }
        void MainWindow_ConnectionSuccess()
        {
            btn_search.IsEnabled = true;
            btn_createPC.IsEnabled = true;
            cmbx_StartIndex.IsEnabled = true;

            txb_username.IsEnabled = false;
            pbx_password.IsEnabled = false;
            cmbx_domain.IsEnabled = false;
            btn_connect.IsEnabled = false;

            pbx_password.Password = "12345678";
        }
        void OULoader(DirectoryEntry de)
        {
            try
            {
                int i = 0;
                tr_view.Items.Clear();
                
                if (de.Children == null)
                    return;

                foreach (DirectoryEntry entry in de.Children)
                {
                    TreeViewItem tr = new TreeViewItem();
                    if (entry.Name.Contains("Шариков"))
                        continue;
                    tr.Header = entry.Name.Substring(3);
                    tr_view.Items.Add(tr);
                    i++;
                }

                _brush = new SolidColorBrush(Colors.Green);
                btn_connect.Background = _brush;
                lbl_info.Content = "Information: Connection Success!\t" + "Groups in OU BIN BRANCHES: " + i.ToString();

                ConnectionSuccess();
            }
            catch (DirectoryServicesCOMException)
            { MessageBox.Show("Login or password are not incorrect!\r\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally
            { de.Dispose(); }
        }
        private async void btn_search_Click(object sender, RoutedEventArgs e)
        {
            btn_search.IsEnabled = false;
            double size = lbl_freePC.FontSize;
            lbl_freePC.FontSize = 40.0;
            lbl_freePC.Content = "Searching...";

            int startNumber = 1;
            switch(cmbx_StartIndex.SelectedIndex)
            {
                case 0:
                    startNumber = 1;
                    break;
                case 1:
                    startNumber = 1000;
                    break;
                case 2:
                    startNumber = 2000;
                    break;
                case 3:
                    startNumber = 3000;
                    break;
                case 4:
                    startNumber = 4000;
                    break;
                case 5:
                    startNumber = 5000;
                    break;
            }
            var tsk = await Task<int>.Factory.StartNew(() => SearchPC(startNumber));

            string qw = Convert.ToString(tsk.ToString());
            lbl_freePC.FontSize = size;
            currentPC = String.Format("MOS-" + qw.PadLeft(4, '0'));
            lbl_freePC.Content = currentPC;
            btn_search.IsEnabled = true;

        }
        private void tr_view_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = tr_view.SelectedItem as TreeViewItem;
            currentBranch = item.Header.ToString();
        }
        private int SearchPC(int startNumber)
        {
            pcx = new PrincipalContext(ContextType.Domain, domain, username, password);
            GroupPrincipal group = GroupPrincipal.FindByIdentity(pcx, "Domain Computers");
            PrincipalCollection collection = group.Members;

            allPC = new List<int>();
            freePC = new List<int>();
            int temp = 0;
            int result;
            string str = null;

            foreach (Principal p in collection)
            {
                temp = p.Name.IndexOf("mos-", StringComparison.OrdinalIgnoreCase);
                if (temp != -1)
                {
                    str = p.Name.Substring(temp + 4);
                    if (Int32.TryParse(str, out result))
                    {
                        if (result >= startNumber)
                            allPC.Add(result);
                    }
                }
            }

            allPC.Sort();

            int pcCount = allPC.Count;
            int q = 1;
            int t = startNumber;

            for (int i = 0; i < pcCount; i++)
            {
                q = t;
                for (; q < allPC[pcCount - 1]; )
                {
                    if (allPC[i] != q)
                    {
                        freePC.Add(q);
                        q++;
                        continue;
                    }
                    t = q + 1;

                    break;
                }
            }
            q = freePC[0];
            allPC.Clear();
            freePC.Clear();
            return q;
        }
        private void btn_connect_Click(object sender, RoutedEventArgs e)
        {
            domain = cmbx_domain.SelectionBoxItem.ToString();
            username = txb_username.Text;
            password = pbx_password.Password;

            OULoader(new DirectoryEntry("LDAP://ou=bin branches,dc=bin,dc=bank", username, password));
        }
        private void btn_createPC_Click(object sender, RoutedEventArgs e)
        {
            if (currentPC == null || currentBranch == null)
            {
                MessageBox.Show("Before createing new PC, you must select Current Branch and generate free PC name!", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            MessageBoxResult mbr = MessageBox.Show(String.Format("Create new PC with name {0} in OU {1}", currentPC, currentBranch), "Agree or disagree?", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (mbr == MessageBoxResult.No) return;
            if (mbr == MessageBoxResult.Yes)
            {
                try
                {
                    pcx = new PrincipalContext(ContextType.Domain, "bin.bank", String.Format("OU={0},OU=BIN BRANCHES,DC=BIN,DC=BANK", currentBranch), username, password);
                    ComputerPrincipal comp = new ComputerPrincipal(pcx, currentPC, "", true);

                    if (ckbx_description.IsChecked == true)
                    {
                        string diskrip = Interaction.InputBox("Input a description if needed.", "Description for " + currentPC, "Иванов И. В.");
                        comp.Description = (diskrip == "") ? null : diskrip;
                    }
                    comp.Save();
                    MessageBox.Show("Successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { pcx.Dispose(); }
            }
        }
        private bool GetFrameWorkVersion()
        {
            int state = 0;
            try
            {
                state = 1;
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                {
                    state = 2;
                    if ((ndpKey != null) && (ndpKey.GetValue("Install") != null) && ((int)ndpKey.GetValue("Install") != 0) && (ndpKey.GetValue("Release") != null))
                    {
                        state = 3;
                        if ((int)ndpKey.GetValue("Release") >= 378389) //378389 - номер версии framework 4.5
                        {
                            state = 4;
                            return true;
                        }
                    }
                    state = 5;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"State = " + state.ToString()); return false; }
        }

        private void menuItem_FSC_Click(object sender, RoutedEventArgs e)
        {
            Window FSCWindow = new Window();
            
        }
    }
}
