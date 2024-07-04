using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eng4You.Models
{
    public class AddBooks
    {
        public int Id { get; set; }
        public string FrontBookImageinEnglish { get; set; }
        public byte[] RowVersionFrontBookImageinEnglish { get; set; }

        public string FrontBookImageinArabic { get; set; }
        public byte[] RowVersionFrontBookImageinArabic { get; set; }

        public string FrontBookImageinTurkish { get; set; }
        public byte[] RowVersionFrontBookImageinTurkish { get; set; }

        public string BackBookImage { get; set; }
        public byte[] RowVersionBackBookImage { get; set; }


        public string UrlSeeBookinEnglish { get; set; }
        public string UrlSeeBookinArabic { get; set; }
        public string UrlSeeBookinTurkish { get; set; }

        public string BookDescriptioninEnglish { get; set; }
        public string BookDescriptioninArabic { get; set; }
        public string BookDescriptioninTurkish { get; set; }

        public string AoutherNameinEnglish { get; set; }
        public string AoutherNameinArabic { get; set; }
        public string AoutherNameinTurkish { get; set; }
    }
}