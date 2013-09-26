using System.Linq;
using System.Windows;
using System.Windows.Input;
using SongHistory.Data;

namespace SongHistory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtSpreadsheet.Text = Properties.Settings.Default.Spreadsheet;
            txtEmail.Text = Properties.Settings.Default.DefaultEmail;
            txtPassword.Password = Properties.Settings.Default.DefaultPassword;
        }

        private void GetHistory_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            
            var service = new SongHistoryService(txtEmail.Text, txtPassword.Password, txtSpreadsheet.Text);
            var data = service.GetUnsung().OrderBy(r => r.LastSung).ToList();
            dataGrid.ItemsSource = data;

            Cursor = Cursors.Arrow;
        }
    }
}
