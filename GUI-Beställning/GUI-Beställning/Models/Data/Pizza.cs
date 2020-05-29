using System;
using System.Collections.Generic;

namespace GUI_Beställning.Models.Data
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        
        public List<Ingredient> Ingredients { get; set; }

    }
}
