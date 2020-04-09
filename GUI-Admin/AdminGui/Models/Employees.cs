using System;
using System.Collections.Generic;
using System.Text;

namespace AdminGui.Models
{
    class Employees
    {
        
        public string Name { get; set; }
        public string Position { get; set;  }
        public int Id { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
