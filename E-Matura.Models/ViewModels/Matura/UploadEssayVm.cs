using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using E_Matura.Models.Enums;

namespace E_Matura.Models.ViewModels.Matura
{
    public class UploadEssayVm
    {
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase EssayUpload { get; set; }
    }
}
