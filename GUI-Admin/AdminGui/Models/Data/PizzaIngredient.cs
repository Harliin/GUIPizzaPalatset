using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Admin
{
    public class PizzaIngredient
    {
        public string Pizza { get; set; }
        public string Ingredient { get; set; }
        public int PizzaID { get; internal set; }
        public int IngredientId { get; internal set; }
    }
}
