using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MarketWPF
{
    /// <summary>
    /// Interaction logic for add.xaml
    /// </summary>
    public partial class add : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Product> sebet;

        public ObservableCollection<Product> Basket
        {
            get { return sebet; }
            set
            {
                sebet = value;
                OnPropertyChanged();
            }
        }
        public add()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numericValue;
            if (textbox_money.Text!=null && textbox_name.Text != null )
            {
                bool isNumber = int.TryParse(textbox_money.Text, out numericValue);
                if(isNumber==true)Basket.Add(new Product( textbox_name.Text,double.Parse(textbox_money.Text),1, "https://i.ytimg.com/vi/xtSSmQ2UQU8/maxresdefault.jpg"));
            }
        }
    }
}
