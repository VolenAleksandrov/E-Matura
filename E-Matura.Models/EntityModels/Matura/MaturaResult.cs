using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.Enums;

namespace E_Matura.Models.EntityModels.Matura
{
    public class MaturaResult
    {
        public int Id { get; set; }
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
        public double Rating { get; set; }
        public User User { get; set; }
        public DateTime DateOfTake { get; set; }
    }
}
