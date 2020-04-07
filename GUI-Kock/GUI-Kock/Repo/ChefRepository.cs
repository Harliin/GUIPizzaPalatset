using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using static Food.Order;
using Food;

namespace DB_Kock
{
    public class ChefRepository : IRepository
    {
        private string ConnectionString { get; }
        private IDbConnection connection { get; }

        public ChefRepository()
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


        public IEnumerable<Employee> GetChefs(string userName, string Password)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Employee> chef = connection.Query<Employee>("\"GetChefs\"", new { username = userName, passcode = Password }, commandType: CommandType.StoredProcedure);
                return chef;
            }
        }

        public IEnumerable<Employee> GetChefsList()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Employee> chefs = connection.Query<Employee>("\"GetChefsList\"", new {}, commandType: CommandType.StoredProcedure);
                return chefs;
            }
        }

        public Pizza GetPizzaByID(int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                Pizza pizza = (connection.Query<Pizza>("\"ShowPizzaByID\"", new { inid = pizzaID }, commandType: CommandType.StoredProcedure)).First();

                pizza.Ingredients = (connection.Query<Ingredient>("\"ShowPizzaIngredientsByID\"", new { inid = pizza.ID }, commandType: CommandType.StoredProcedure)).ToList();
                return pizza;
            }
        }
        public IEnumerable<Order> ShowOrderByStatus(eStatus Status)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = connection.Query<Order>("\"ShowOrderByStatus\"", new { status = (int)Status }, commandType: CommandType.StoredProcedure);
                foreach (Order order in orders)
                {
                    order.pizza = (connection.Query<Pizza>("\"GetOrderPizzas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.pasta = (connection.Query<Pasta>("\"GetOrderPastas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.sallad = (connection.Query<Sallad>("\"GetOrderSallads\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.drink = (connection.Query<Drink>("\"GetOrderDrinks\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.extra = (connection.Query<Extra>("\"GetOrderExtras\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                }
                return orders;
            }
        }

        public Order ShowOrderByID(int id)
        {
            using (IDbConnection con = Connection)
            {

                Order order = ( connection.Query<Order>("\"ShowOrderByID\"", new { inid = id }, commandType: CommandType.StoredProcedure)).First();

                order.pizza = ( connection.Query<Pizza>("\"GetOrderPizzas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.pasta = ( connection.Query<Pasta>("\"GetOrderPastas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.sallad = ( connection.Query<Sallad>("\"GetOrderSallads\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.drink = ( connection.Query<Drink>("\"GetOrderDrinks\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.extra = ( connection.Query<Extra>("\"GetOrderExtras\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();

                return order;
            }
        }

        public async Task<IEnumerable<Order>> ShowFinishedOrderID()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = (await connection.QueryAsync<Order>("\"ShowFinishedOrderID\"", commandType: CommandType.StoredProcedure)).ToList();
                return orders;
            }
        }

        public void UpdateOrderStatus(int id)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Order>("\"UpdateOrderStatus\"", new { inid = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<PizzaIngredient> pizzaIngredients = await connection.QueryAsync<PizzaIngredient>("\"ShowPizzaIngredients\"", commandType: CommandType.StoredProcedure);
                return pizzaIngredients;
            }
        }

        public IEnumerable<Pizza> ShowPizzas()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizzas = connection.Query<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure);
                return pizzas;
            }
        }

        public IEnumerable<Ingredient> ShowIngredientsAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Ingredient> ingredients = connection.Query<Ingredient>("\"GetIngredients\"", commandType: CommandType.StoredProcedure);
                return ingredients;
            }
        }

        public async Task<IEnumerable<Pasta>> ShowPastasAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pasta> pastas = await connection.QueryAsync<Pasta>("\"GetPastas\"", commandType: CommandType.StoredProcedure);
                return pastas;
            }
        }

        public async Task<IEnumerable<Sallad>> ShowSalladsAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Sallad> sallads = await connection.QueryAsync<Sallad>("\"GetSallads\"", commandType: CommandType.StoredProcedure);
                return sallads;
            }
        }

        public async Task<IEnumerable<Drink>> ShowDrinksAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Drink> drinks = await connection.QueryAsync<Drink>("\"GetDrinks\"", commandType: CommandType.StoredProcedure);
                return drinks;
            }
        }

        public async Task<IEnumerable<Extra>> ShowExtraAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Extra> drinks = await connection.QueryAsync<Extra>("\"GetExtras\"", commandType: CommandType.StoredProcedure);
                return drinks;
            }
        }
    }
}
