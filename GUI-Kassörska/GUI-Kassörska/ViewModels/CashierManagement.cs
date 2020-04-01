using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GUI_Kassörska.ViewModels.Order;

namespace GUI_Kassörska.ViewModels
{
    public class CashierManagement
    {
        ////Kassörskans meny
        //public static CashierRepository repo = new CashierRepository();
        //public async Task CashierActions()
        //{
        //    do
        //    {
        //        var orders = repo.ShowAllOrders();
        //        List<Order> orderList = orders.ToList();

        //        //Skriver ut pågående ordrar
        //        foreach (var order in orders)
        //        {
        //            if (order.Status != eStatus.Avhämtad && order.Status != eStatus.Klar)
        //            {
        //                //Console.WriteLine($"Order-ID: {order.ID}\tStatus: {order.Status}");
        //            }
        //        }

        //        // Skriver ut färdiga ordrar
        //        foreach (var order in await repo.ShowOrderByStatusAsync(eStatus.Klar))
        //        {
        //            //Console.WriteLine($"Order-ID: {order.ID}\tStatus: {order.Status}");
        //        }

        //        //Markera order som uthämtad
        //        IEnumerable<Order> ordersByStatus = await repo.ShowOrderByStatusAsync(eStatus.Klar);

        //        List<Order> listOfOrders = ordersByStatus.ToList();

        //        int orderid = GetValidOrderID(listOfOrders);
        //        await repo.UpdateOrderStatus(orderid);
        //        //Console.WriteLine($"Markerar order {orderid} som uthämtad");
        //        //Thread.Sleep(2000);
        //        //await CashierManagement();
        //    }
        //    while (true);
        //}

        ////Syftet med funktionen är att returnera ett giltigt orderID.
        ////Giltigt orderID är ett nummer som finns i listan över färdiga ordrar
        //private int GetValidOrderID(List<Order> listOfOrders)
        //{
        //    bool isValid;
        //    int orderID = -1;
        //    do
        //    {
        //        isValid = int.TryParse(Console.ReadLine(), out int cashierOrderChoice);
        //        if (isValid)
        //        {
        //            if ((listOfOrders.Exists(x => x.OrderID == cashierOrderChoice)))
        //            {
        //                orderID = cashierOrderChoice;
        //            }
        //            else
        //            {
        //                isValid = false;
        //            }
        //        }

        //        if (isValid == false)
        //        {
        //            Console.Write("Ordernumret är ogiltigt! Ange nytt ordernummer: ");
        //        }
        //    }
        //    while (isValid == false);
        //    return orderID;
        //}
    }
}
