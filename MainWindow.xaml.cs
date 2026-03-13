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
using Budweg2._0.VievModels;
using Budweg2._0.Models;

namespace Budweg2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mvm = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void btnSaveNewDeliveryNote_Click(object sender, RoutedEventArgs e)
        {
            int startQuantity = int.Parse(tbxQuantity.Text);
            int itemNo = int.Parse(tbxItemNo.Text);
            
            DeliveryNote deliverynote = new DeliveryNote(startQuantity, itemNo);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }   
    }
}               