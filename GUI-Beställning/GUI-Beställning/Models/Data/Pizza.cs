using System;
using System.Collections.Generic;

namespace GUI_Beställning.Models.Data
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        private string type;
        public string Type
        {
            get { return type; }

            set
            {
                type = "pizza";
            }
            
        }
        public List<Ingredient> Ingredients { get; set; }

    }
}
