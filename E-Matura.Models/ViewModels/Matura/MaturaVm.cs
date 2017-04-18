using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.EntityModels.Interfaces;
using E_Matura.Models.ViewModels.Questions;

namespace E_Matura.Models.ViewModels.Matura
{
    public class MaturaVm
    {
        public int Time { get; set; }

        public IEnumerable<IQuestionVm> Questions { get; set; }
    }
}
