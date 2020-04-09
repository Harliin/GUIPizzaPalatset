using DB_Admin;
using System.Collections.Generic;
using System.Threading.Tasks;
using Food;

namespace AdminGui
{
    public interface IRepository
    {
        Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients);
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<IEnumerable<Drink>> ShowDrinksAsync();
        Task<IEnumerable<Extra>> ShowExtraAsync();
        Task<IEnumerable<Ingredient>> ShowIngredientsAsync();

        Task<IEnumerable<Pasta>> ShowPastasAsync();
        Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients();
        Task<IEnumerable<Pizza>> ShowPizzasAsync();
        Task<IEnumerable<Sallad>> ShowSalladsAsync();
    }
}