using DB_OrderInfo.Food;
using System.Threading;
using System.Windows;

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

        private static Window_Loaded()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

            // Printar ut pågående och färdiga ordrar
            //Console.WriteLine("Pågående ordrar:\n");
            foreach (Order ongoingOrder in repository.OngoingOrder())
            {
                MessageBox.Show("example message");

            }

            //Console.WriteLine("\nFärdiga ordrar:\n");
            foreach (Order completeOrder in repository.CompleteOrder())
            {
                //Console.WriteLine(completeOrder.ID);
            }
            Thread.Sleep(3000);
            //await Run();
        }
    }
}
