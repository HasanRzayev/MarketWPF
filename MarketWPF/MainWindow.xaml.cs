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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarketWPF
{
    public class Product:INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private double money;
        public Product()
        {

        }
        public Product(string name, double money, int count, string imageurl)
        {
            Name = name;
            Money = money;

            this.imageurl = imageurl;
          
            Count = count;
        }

        public double Money
        {
            get { return money; }
            set { money = value; OnPropertyChanged(); }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value;
                OnPropertyChanged();
            }
        }




        public string imageurl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

       
        public ObservableCollection<Product> products {get; set; }
        public ObservableCollection<Product> sebet = new ObservableCollection<Product>();
        public MainWindow()
        {
            InitializeComponent();
            
            products = new ObservableCollection<Product> { };
            products.Add(new Product("Kola", 7.5, 10 , "https://images.ctfassets.net/6jpeaipefazr/3B7rtjJ16H2X5l0CXcCC2H/9c3589ba77afca615b91cc43f55feee8/P2-5449000054227_T1.jpg?w=1080&h=1080"));
            products.Add(new Product("Fanta", 7.5, 10, "https://fulloption.com.ng/wp-content/uploads/2017/08/365.jpg"));
            products.Add(new Product("Fanta Pineapple", 7.5, 10, "https://www.fanta.com/content/dam/nagbrands/us/fanta/en/products/pineaple/desktop/Pineapple_Bottle_Desktop.png"));
            products.Add(new Product("Pepsi", 7.5, 10, "https://www.ubuy.com.jo/productimg/?image=aHR0cHM6Ly9tLm1lZGlhLWFtYXpvbi5jb20vaW1hZ2VzL0kvNzFNN2xsUjJ3RkwuX1NMMTUwMF8uanBn.jpg"));
            products.Add(new Product("Water", 7.5, 10, "https://camzies.com.ng/wp-content/uploads/2016/09/45.jpg"));
            products.Add(new Product("Snickers", 7.5, 10, "https://cocoaffaire.com/wp-content/uploads/2021/11/SNICKERS-SINGLE-50-GM.jpg"));
            products.Add(new Product("Bounty", 7.5, 10, "https://nordicexpatshop.com/media/catalog/product/cache/a75b4628650e2182ad447c229a356118/b/o/bounty-candy-bar-57gr.jpeg"));
            products.Add(new Product("Mars", 7.5, 10, "https://cocoaffaire.com/wp-content/uploads/2021/10/Mars-51gm-600x600-1.png"));
            products.Add(new Product("Twis", 7.5, 10, "https://m.media-amazon.com/images/I/4192VyvQjcL.jpg"));
            products.Add(new Product("7Days", 7.5, 10, "https://m.media-amazon.com/images/I/81fFfDD9adL._SL1500_.jpg"));
            products.Add(new Product("Lays-Klassic", 7.5, 10, "https://cdn1.ozone.ru/s3/multimedia-9/c1200/6255833361.jpg"));
            products.Add(new Product("Lays", 7.5, 10, "https://strgimgr.umico.az/sized/840/144094-011dc1e9f99b0453c39ce0b7212c0535.jpg"));
            products.Add(new Product("Lays-Barbecue", 7.5, 10, "https://i.ebayimg.com/thumbs/images/g/N~kAAOSwGHFhWI19/s-l300.jpg"));
            products.Add(new Product("DORITOS® Salsa Verde Flavored Tortilla Chips", 7.5, 10, "https://www.doritos.com/sites/doritos.com/files/styles/product_thumbnail/public/2018-08/new-salsa-verde.png?itok=1eYqxntK"));
            products.Add(new Product("DORITOS® Nacho Cheese Flavored Tortilla Chips", 7.5, 10, "https://www.doritos.com/sites/doritos.com/files/2018-08/new-nacho-cheese.png"));
            products.Add(new Product("DORITOS® FLAMIN' HOT® Nacho Flavored Tortilla Chips", 7.5, 10, "https://www.doritos.com/sites/doritos.com/files/2019-01/Doritos%20FHN%20XXL.png"));

            products.Add(new Product("PRINGLES® ORIGINAL CRISPS", 7.5, 10, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/pringles-template-original-1546635620.jpg?crop=1xw:1xh;center,top&resize=768:*"));

            products.Add(new Product("PRINGLES® CHEDDAR & SOUR CREAM CRISPS", 7.5, 10, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/pringles-template-cheddarsourcream-1546635618.jpg?crop=1xw:1xh;center,top&resize=768:*"));

            products.Add(new Product("PRINGLES® PIZZA CRISPS", 7.5, 10, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/pringles-template-pizza-1546635620.jpg?crop=1xw:1xh;center,top&resize=768:*"));

            products.Add(new Product("PRINGLES® ROTISSERIE CHICKEN CRISPS", 7.5, 10, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/pringles-template-nashvillehc-1546635620.jpg?crop=1xw:1xh;center,top&resize=768:*"));

            stand.ItemsSource = products;
            DataContext = this;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(stand.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(textbox_serach.Text))
                return true;
            else
                return ((item as Product).Name.IndexOf(textbox_serach.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button btn)
            {
          
                    foreach (var item in sebet)
                    {
                        if (item.Name ==(sender as Button).Tag.ToString())
                        {

                            item.Count++;
                        foreach (var items in products)
                        {
                            if (items.Name == (sender as Button).Tag.ToString())
                            {

                                items.Count--;
                                return;

                            }
                        }

                        }
                    }
                
            }
           
                if (sender is Button btn2)
                {
                    foreach (var item in products)
                    {
                        if ((item as Product).Name == btn2.Tag.ToString())
                        {
                            Product lazim = new Product(btn2.Tag.ToString(),(item as Product).Money,1, (item as Product).imageurl);
                    
                     
                            sebet.Add(lazim);
                            item.Count--;
                        }
                    }
               
                }

            


        }

        private void btn_sebet_Click(object sender, RoutedEventArgs e)
        {
            Sebet sebetwindow = new Sebet();
            sebetwindow.Basket = sebet;
            sebetwindow.Products = products;
            sebetwindow.ShowDialog();

        }

      

        private void Addproduct_Click(object sender, RoutedEventArgs e)
        {
            add elavepencere = new add();
            elavepencere.Basket = products;
            elavepencere.ShowDialog();
        }



        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Edit editpencere = new Edit();
            editpencere.Basket = products;
            editpencere.lazim = (sender as Button).Tag.ToString();
            editpencere.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(stand.ItemsSource).Refresh();
        }
    }
}
