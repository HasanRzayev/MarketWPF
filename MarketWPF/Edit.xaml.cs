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
    /// Interaction logic for Edit.xaml
    /// </summary>

    public partial class Edit : Window, INotifyPropertyChanged
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
        public string lazim { get; set; }
        public Edit()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            double numericValue;
            bool isNumber = double.TryParse(textbox_money.Text, out numericValue);
            if (isNumber == false) return;
            foreach (var item in Basket)
            {
                
  
                if (textbox_money.Text != null && textbox_name.Text != null )
                {
                    if (item.Name == lazim)
                    {
             
                        item.Name = textbox_name.Text;
                        item.Money = double.Parse(textbox_money.Text);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Basket)
            {
                if (item.Name == lazim)
                {
                    textbox_name.Text = item.Name;
                    textbox_money.Text = item.Money.ToString();
                }
            }
        }
    }
}
