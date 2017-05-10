using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Matura.Models.EntityModels.Matura;
using E_Matura.Models.ViewModels.Matura;

namespace E_Matura.Services
{
    public class AccountService : Service
    {
        public List<MaturaResultVm> GetUserResults(string userId)
        {
            var user = this.Context.Users.Entities.First(c => c.Id == userId);
            var results = this.Context.MaturaResults.Entities.Where(m => m.User == user);
            List<MaturaResultVm> resultVms = new List<MaturaResultVm>();
            foreach (var result in results)
            {
                resultVms.Add(Mapper.Map<MaturaResult, MaturaResultVm>(result));
            }
            return resultVms;
        }
    }
}
