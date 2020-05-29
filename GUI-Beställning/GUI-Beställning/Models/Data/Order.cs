using System.Collections.Generic;

namespace GUI_Beställning.Models.Data
{
    public class Order
    {
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public int EmployeeID {get;set;}
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4}
        public List<Pizza> pizza { get; set; }
        public List<Pasta> pasta { get; set; }
        public List<Sallad> sallad { get; set; }
        public List<Drink> drink { get; set; }
        public List<Extra> extra { get; set; }

        public enum eFoodType { pizza = 1, pasta = 2, sallad = 3, drink = 4, extra = 5}
        public eFoodType FoodType { get; set; }
    }
}
