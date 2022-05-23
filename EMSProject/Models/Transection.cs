using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSProject.Models
{
    public class Transection
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  Position { get; set; }
        public decimal Salary { get; set; }
        public int EmpId{ get; set; }
    }
}
