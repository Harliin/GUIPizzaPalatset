using System;
using System.Collections.Generic;
using System.Text;


namespace GUI_Beställning.Models.Data
{
    public class Drink
    {
        public int ID { get; set; }

        public int OrderID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
