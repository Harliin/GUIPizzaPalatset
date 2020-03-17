using System.Data;
using System.Data.SqlClient;

namespace GUI_OrderInfo.Repository
{
    class Repository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public static int Backend { get; set; }
        public Repository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }
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
        // Beställnings Repositorys
        //public async Task RemovePizzaFromOrder(int orderID, int pizzaID)
        //{
        //    using (IDbConnection con = Connection)
        //    {
        //        await connection.QueryAsync<Pizza>("\"RemovePizzaFromOrder\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
        //    }
        //}
    }
}
