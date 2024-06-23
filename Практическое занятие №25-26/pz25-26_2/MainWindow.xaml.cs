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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Пз25_26._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IOrderFactory orderFactory; 
        public MainWindow(IOrderFactory orderFactory)
        {
            InitializeComponent();
            this.orderFactory = orderFactory;
        }
        public MainWindow() : this(new HomeDeliveryOrderFactory())
        {

        }
        public interface IOrderFactory
        {
            Order CreateOrder();
            OrderItem CreateOrderItem();
        }
        public class HomeDeliveryOrderFactory : IOrderFactory
        {
            public Order CreateOrder()
            {
                return new HomeDeliveryOrder();
            }
            public OrderItem CreateOrderItem()
            {
                return new HomeDeliveryOrderItem();
            }
        }
        public class InStoreOrderFactory : IOrderFactory
        {
            public Order CreateOrder()
            {
                return new InStoreOrder();
            }
            public OrderItem CreateOrderItem()
            {
                return new InStoreOrderItem();
            }
        }
        public class HomeDeliveryOrder : Order
        {
            public string DeliveryAddress {get; set;}
        }
        public class InStoreOrder : Order
        {
            public DateTime PickupTime {get; set;}
        }
        public class HomeDeliveryOrderItem : OrderItem
        {
            public bool IsGiftWrapped {get; set;}
        }
        public class InStoreOrderItem : OrderItem
        {
            public string PickupLocation {get; set;}
        }
        public class Order
        {
            public string Name {get; set;}
            public List<OrderItem> Items {get; set;}
        }
        public class OrderItem
        {
            public string Product {get; set;}
            public decimal Price {get; set;}
            public int Count {get; set;}
            public string Opis {get; set;}
        }
        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = orderFactory.CreateOrder();
            order.Items = new List<OrderItem>
            {
                orderFactory.CreateOrderItem()
            };
            OrderList.Items.Add(order);
        }
    }
}
