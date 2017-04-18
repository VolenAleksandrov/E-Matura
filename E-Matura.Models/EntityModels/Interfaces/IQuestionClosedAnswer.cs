using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.EntityModels.Answers;

namespace E_Matura.Models.EntityModels.Interfaces
{
    public interface IQuestionClosedAnswer
    {
        IEnumerable<ClosedAnswer> Answers { get; set; }
    }
}
