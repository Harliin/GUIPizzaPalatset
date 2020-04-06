using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GUI_Kassörska.ViewModels;
using static GUI_Kassörska.ViewModels.Order;

namespace GUI_Kassörska
{
    public class CashierRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public static int Backend { get; set; }
        private IDbConnection Connection
        {
            get
            {
                IDbConnection con;
                con = new SqlConnection(ConnectionString);
                con.Open();
                return con;
            }
        }

        //Anslutning till databasen
        public CashierRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);   
        }

        //Visa order med statusnummer
        public IEnumerable<Order> ShowOrderByStatus(eStatus status)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> ordersByStatus = connection.Query<Order>("\"ShowOrderByStatus\"", new { status = (int)status }, commandType: CommandType.StoredProcedure);
                return ordersByStatus;
            }
        }

        //Uppdatera orderns status
        public void UpdateOrderStatus(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Order>("\"UpdateOrderStatus\"",
                new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
            }
        }

        //Ta bort order
        public void DeleteOrder(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Order>("\"DeleteOrder\"", new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
            }
        }

        //Visa alla ordrar
        public IEnumerable<Order> ShowAllOrders()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> allOrders = connection.Query<Order>("\"ShowOrders\"", commandType: CommandType.StoredProcedure);
                return allOrders;
            }
        }
        
        //public async Task<IEnumerable<Order>> ShowOrdersWithStatusOneAndTwo()
        //{
        //    using (IDbConnection con = Connection)
        //    {
        //        return (await connection.QueryAsync<Order>("\"ShowOrdersWithStatusOneAndTwo\"", commandType: CommandType.StoredProcedure));
        //    }
        //}

        public int ShowOrderByID(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
                var result = connection.Query<Order>("\"ShowOrderByID\"", new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
                var order = result.First();
                return order.ID;
            }
        }
    }
}