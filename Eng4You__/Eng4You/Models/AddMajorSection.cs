using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eng4You.Models
{
    public class AddMajorSection
    {
        public int Id { get; set; }
        public string NameofMajor { get; set; }
        public string NameofMajorinArabic { get; set; }

        public string NameofMajorinTurkish { get; set; }

        public string MajorImage { get; set; }
        public string UrlName { get; set; }

        public byte[] RowVersion { get; set; }
        public string FrontBookImageinEnglish { get; internal set; }
        public string FrontBookImageinArabic { get; internal set; }
        public string FrontBookImageinTurkish { get; internal set; }
    }
}