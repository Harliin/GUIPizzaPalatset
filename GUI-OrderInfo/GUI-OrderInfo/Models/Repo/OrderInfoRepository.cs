using Dapper;
using DB_OrderInfo;
using DB_OrderInfo.Food;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GUI_OrderInfo
{
    public class OrderInfoRepository : IRepository
    {
        // Connection properties
        private string ConnectionString { get; }
        private IDbConnection connection { get; set; }

        #region Connection string constructor
        public OrderInfoRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
        }
        #endregion

        private IDbConnection Connection
        {
            get
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
        }

        #region Metoder för Stored Procedures
        public IEnumerable<Order> OngoingOrder()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> ongoingOrder = (connection.Query<Order>("\"DisplayOngoingOrder\"", commandType: CommandType.StoredProcedure));
                return ongoingOrder;
            }
        }
        public IEnumerable<Order> CompleteOrder()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> completeOrder = (connection.Query<Order>("\"DisplayCompleteOrder\"", commandType: CommandType.StoredProcedure));
                return completeOrder;
            }
        }
        #endregion
    }
}
