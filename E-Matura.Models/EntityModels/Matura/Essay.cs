using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.Enums;

namespace E_Matura.Models.EntityModels.Matura
{
    public class Essay
    {
        public int Id { get; set; }
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
        public string FilePath { get; set; }
        public User Author { get; set; }
        public double Rationg { get; set; }
    }
}
