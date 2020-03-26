using DB_OrderInfo.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_OrderInfo.ViewModels
{
    /// <summary>
    /// Interaction logic for MainWindowViewModel.xaml
    /// </summary>
    public partial class MainWindowViewModel : Window
    {
        public static OrderInfoRepository repo;

        public MainWindowViewModel()
        {
            InitializeComponent();

            var loaded = Window_Loaded();
        }

        //public static async Task Main(object sender, RoutedEventArgs e)
        //{
        //    //await ChooseBackend();
        //    do
        //    {
        //        Thread.Sleep(1550);// Sidan uppdateras varje 1,5 sekunder
        //        await Run();
        //    } while (true);
        //}

        //static async Task Run()
        //{
        //    OrderInfoRepository repository = new OrderInfoRepository();

        //    // Printar ut pågående och färdiga ordrar
        //    //Console.WriteLine("Pågående ordrar:\n");
        //    foreach (Order ongoingOrder in await repository.OngoingOrder())
        //    {
        //        MessageBox.Show("sample message");

        //    }

        //    //Console.WriteLine("\nFärdiga ordrar:\n");
        //    foreach (Order completeOrder in await repository.CompleteOrder())
        //    {
        //        //Console.WriteLine(completeOrder.ID);
        //    }
        //    Thread.Sleep(3000);
        //    await Run();
        //}

        private static async Task Window_Loaded()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

            // Printar ut pågående och färdiga ordrar
            //Console.WriteLine("Pågående ordrar:\n");
            foreach (Order ongoingOrder in await repository.OngoingOrder())
            {
                MessageBox.Show("example message");

            }

            //Console.WriteLine("\nFärdiga ordrar:\n");
            foreach (Order completeOrder in await repository.CompleteOrder())
            {
                //Console.WriteLine(completeOrder.ID);
            }
            Thread.Sleep(3000);
            //await Run();
        }
    }
}
