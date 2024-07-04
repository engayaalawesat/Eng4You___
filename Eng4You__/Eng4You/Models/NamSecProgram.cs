using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eng4You.Models
{
    public class NemSecProgram
    {
        public int Id { get; set; }

        public string NamSecProgram { get; set; }

        [Display(Name = "NemSecProgram")]
        public int ProgramId { get; set; }
        public virtual ICollection<Programmes> Programmes { get; set; }
    }
}