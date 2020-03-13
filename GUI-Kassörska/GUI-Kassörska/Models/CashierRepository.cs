using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GUI_Kassörska.ViewModels;

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
        public CashierRepository()
        {

                ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
                connection = new SqlConnection(ConnectionString);
            
        }
        public async Task<IEnumerable<Order>> ShowOrderByStatusAsync(eStatus status)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = await connection.QueryAsync<Order>("\"ShowOrderByStatus\"", new { status = (int)status }, commandType: CommandType.StoredProcedure);
                return orders;
            }
        }

        //Uppdatera orderns status
        public async Task UpdateOrderStatus(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Order>("\"UpdateOrderStatus\"",
                new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
            }
        }

        //Ta bort order
        public async Task DeleteOrder(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Order>("\"DeleteOrder\"",
                new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
            }
        }

        //Visa alla ordrar
        public async Task<IEnumerable<Order>> ShowAllOrdersAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> allOrders = (await connection.QueryAsync<Order>("\"ShowOrders\"", commandType: CommandType.StoredProcedure));
                return allOrders;
            }

        }
    }
}
