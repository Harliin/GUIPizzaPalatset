using DB_OrderInfo;
using DB_OrderInfo.Food;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_OrderInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static OrderInfoRepository repo;
        static async Task Main(string[] args)
        {
            //await ChooseBackend();
            do
            {
                Thread.Sleep(1550);// Sidan uppdateras varje 1,5 sekunder
                await Run();
            } while (true);
        }

        static async Task Run()
        {
            Console.Clear();
            OrderInfoRepository repository = new OrderInfoRepository();

            // Printar ut pågående och färdiga ordrar
            Console.WriteLine("Pågående ordrar:\n");
            foreach (Order ongoingOrder in await repository.OngoingOrder())
            {
                //Console.WriteLine(ongoingOrder.ID);

            }

            Console.WriteLine("\nFärdiga ordrar:\n");
            foreach (Order completeOrder in await repository.CompleteOrder())
            {
                //Console.WriteLine(completeOrder.ID);
            }
            Thread.Sleep(3000);
            await Run();
        }

    }
}
