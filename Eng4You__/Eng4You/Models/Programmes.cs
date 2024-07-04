using Eng4You.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eng4You.Models
{
    public class Programmes
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public virtual NemSecProgram NemSecProgram { get; set; }
    }

}
