﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GUI_Beställning.Models.Data;
using System;
using Newtonsoft.Json;


namespace GUI_Beställning.Models.Data
{ 
    public class OrderRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public static int Backend { get; set; }
        public OrderRepository()
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
        public void RemovePizzaFromOrder(int orderID, int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Pizza>("\"RemovePizzaFromOrder\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void RemovePastaFromOrder(int orderID, int pastaID)
        {
            using (IDbConnection con = Connection)
            {
                 connection.Query<Pasta>("\"RemovePastaFromOrder\"", new { orderid = orderID, pastaid = pastaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void RemoveSalladFromOrder(int orderID, int salladID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Sallad>("\"RemoveSalladFromOrder\"", new { orderid = orderID, salladid = salladID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void RemoveDrinkFromOrder(int orderID, int drinkID)
        {
            using (IDbConnection con = Connection)
            {
                 connection.Query<Drink>("\"RemoveDrinkFromOrder\"", new { orderid = orderID, drinkid = drinkID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void RemoveExtraFromOrder(int orderID, int extraID)
        {
            using (IDbConnection con = Connection)
            {
            }
                connection.Query<Extra>("\"RemoveExtraFromOrder\"", new { orderid = orderID, extraid = extraID }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Order> CreateNewOrder()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> order = ( connection.Query<Order>("\"CreateNewOrder\"", commandType: CommandType.StoredProcedure));
                return order;
            }
        }
        public void AddPizzaToOrder(int orderID, int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Pizza>("\"sp_OrderPizza\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateOrderStatus(int orderID)
        {
            using (IDbConnection con = Connection)
            {
                 connection.Query<Order>("\"UpdateOrderStatus\"", new { inid = orderID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void AddPastaToOrder(int orderID, int pastaID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Pasta>("\"sp_OrderPasta\"", new { orderid = orderID, pastaid = pastaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void AddSalladToOrder(int orderID, int salladID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Sallad>("\"sp_OrderSallad\"", new { orderid = orderID, salladid = salladID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void AddDrinkToOrder(int orderID, int drinkID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Drink>("\"sp_OrderDrink\"", new { orderid = orderID, drinkid = drinkID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void AddExtraToOrder(int orderID, int extraID)
        {
            using (IDbConnection con = Connection)
            {
                connection.Query<Extra>("\"sp_OrderExtra\"", new { orderid = orderID, extraid = extraID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddOrderToReceipt( string Json, int totalPrice, DateTime Date)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Order>("\"AddOrderToReceipt\"", new { json = Json, totalprice = totalPrice, date = Date }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<Pizza> GetPizza(int ID)
        {
            using (IDbConnection con = Connection)
            {
                Pizza pizza = (await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { id = ID }, commandType: CommandType.StoredProcedure)).First();
                pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { id = ID }, commandType: CommandType.StoredProcedure)).ToList();
                return pizza;
            }
        }
        public IEnumerable<Pizza> GetPizzas()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizzas = connection.Query<Pizza>("\"ShowPizzas\"", commandType: CommandType.StoredProcedure);
                foreach (Pizza pizza in pizzas)
                {
                    pizza.Ingredients = (connection.Query<Ingredient>("\"ShowPizzaIngredientsByID\"", new { inid = pizza.ID }, commandType: CommandType.StoredProcedure)).ToList();
                }
                return pizzas;
            }
        }
        public async Task<IEnumerable<Pizza>> ShowPizzaByID(int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizza = await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { inid = pizzaID }, commandType: CommandType.StoredProcedure);
                return pizza;
            }
        }
        public async Task<IEnumerable<Pasta>> ShowPastaByID(int pastaID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pasta> pasta = await connection.QueryAsync<Pasta>("\"ShowPastaByID\"", new { inid = pastaID }, commandType: CommandType.StoredProcedure);
                return pasta;
            }
        }
        public async Task<IEnumerable<Sallad>> ShowSalladByID(int salladID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Sallad> sallad = await connection.QueryAsync<Sallad>("\"ShowSalladByID\"", new { inid = salladID }, commandType: CommandType.StoredProcedure);
                return sallad;
            }
        }
        public async Task<IEnumerable<Drink>> ShowDrinkByID(int drinkID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Drink> drink = await connection.QueryAsync<Drink>("\"ShowDrinkByID\"", new { inid = drinkID }, commandType: CommandType.StoredProcedure);
                return drink;
            }
        }
        public async Task<IEnumerable<Extra>> ShowExtraByID(int extraID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Extra> extra = await connection.QueryAsync<Extra>("\"ShowExtraByID\"", new { inid = extraID }, commandType: CommandType.StoredProcedure);
                return extra;
            }
        }
        public async Task< IEnumerable<Order>> ShowOrderByID(int orderID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = (await connection.QueryAsync<Order>("\"ShowOrderByID\"", new { inid = orderID }, commandType: CommandType.StoredProcedure)).ToList();
                foreach (Order order in orders)
                {
                    order.pizza = (await connection.QueryAsync<Pizza>("\"GetOrderPizzas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.pasta = (await connection.QueryAsync<Pasta>("\"GetOrderPastas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.sallad = (await connection.QueryAsync<Sallad>("\"GetOrderSallads\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.drink = (await connection.QueryAsync<Drink>("\"GetOrderDrinks\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                    order.extra = (await connection.QueryAsync<Extra>("\"GetOrderExtras\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                }
                return orders;
            }
        }
        // Slut Beställning

        // Interface
        public async Task AddPizzaAsync(string Name, int Price)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("\"AddPizza\"", new { name = Name, price = Price }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
        {
            using (IDbConnection con = Connection)
            {
                foreach (var ingredient in ingridients)
                {
                    await connection.QueryAsync<Pizza>("INSERT INTO \"PizzaIngredients\"(\"PizzaID\", \"IngredientsID\") VALUES (\"PizzaID\", \"IngredientID\")", new { pizzaid = pizzaID, ingredientid = ingredient });
                }
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
        public async Task<IEnumerable<Pizza>> ShowPizzasAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("\"ShowPizzas\"", commandType: CommandType.StoredProcedure);
                return pizzas;
            }
        }
        public async Task<IEnumerable<Ingredient>> ShowIngredientsAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("\"ShowIngredients\"", commandType: CommandType.StoredProcedure);
                return ingredients;
            }
        }
        public IEnumerable<Pasta> ShowPastas()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pasta> pastas = connection.Query<Pasta>("\"ShowPastas\"", commandType: CommandType.StoredProcedure);
                return pastas;
            }
        }
        public IEnumerable<Sallad> ShowSallads()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Sallad> sallads = connection.Query<Sallad>("\"ShowSallads\"", commandType: CommandType.StoredProcedure);
                return sallads;
            }
        }
        public IEnumerable<Drink> ShowDrinks()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Drink> drinks = connection.Query<Drink>("\"ShowDrinks\"", commandType: CommandType.StoredProcedure);
                return drinks;
            }
        }
        public IEnumerable<Extra> ShowExtra()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Extra> drinks = connection.Query<Extra>("\"ShowExtras\"", commandType: CommandType.StoredProcedure);
                return drinks;
            }
        }

        public IEnumerable<Order> ShowOrders()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = connection.Query<Order>("\"ShowOrders\"", commandType: CommandType.StoredProcedure);
                return orders;
            }
        }
    }
}
