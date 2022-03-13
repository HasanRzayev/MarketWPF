using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
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
    /// Interaction logic for Sebet.xaml
    /// </summary>
    public partial class Sebet : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Product> sebet;

        public ObservableCollection<Product> Basket
        {
            get { return sebet; }
            set { sebet = value;
                OnPropertyChanged();
            }
        }

        private double umumi;

        public double Umumi
        {
            get { return umumi; }
            set { umumi = value; }
        }


        public Sebet()
        {
            InitializeComponent();

            
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void sebetplus_Click(object sender, RoutedEventArgs e)
        {
       
            if (sender is Button a)
            {
                foreach (Product product in products)
                {
                    if (product.Name == a.Tag.ToString())
                    {
                     

                        if (product.Count -1< 0)
                        {
                            return;
                        }
                        product.Count--;
                        foreach (Product products in sebet)
                        {
                            if (products.Name == a.Tag.ToString())
                            {
                                products.Count++;
                            }
                        }
                    }
                }
              
               
            
            }
          
        }

        private void sebetminus_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button a)
            {
               
                foreach (Product product in sebet)
                {
                    if (product.Name == a.Tag.ToString())
                    {
                    
                        if (product.Count -1 <0)
                        {
                            return;
                        }
                        product.Count--;
                        foreach (Product products in products)
                        {
                            if (products.Name == a.Tag.ToString())
                            {
                                products.Count++;
                            }
                        }
                    }
                }
             
            }
        }

        private void sebetdelete_Click(object sender, RoutedEventArgs e)
        {
            int lazimli=0;
            Product lazim = new Product();
            if (sender is Button a)
            {
                foreach (Product product in sebet)
                {
                    if (product.Name == a.Tag.ToString())
                    {
                      lazimli=product.Count;
                        lazim=product;
                    }
                }
                sebet.Remove(lazim);
                foreach (Product product in products)
                {
                    if (product.Name == a.Tag.ToString())
                    {
                        product.Count+=lazimli;
                    }
                }
                
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

            double lazim = 0;
            foreach (var item in sebet)
            {
                lazim += ((item as Product).Money * (item as Product).Count);
            }
            umumi = lazim;
            umumiqiymet.Content = lazim.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            sebet.Clear ();
            umumiqiymet.Content ="0";

            var producs = JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("baza.json", producs);
        }
    }
}
