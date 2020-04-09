using System;
using System.Collections.Generic;
using System.Text;
using Food;
using System.Linq;
using DB_Admin;

namespace AdminGui
{
    public class MyPizza
    {
        
        
        public string Name { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        
        public override string ToString()
        {
            return this.Name;
        }

    }
}
