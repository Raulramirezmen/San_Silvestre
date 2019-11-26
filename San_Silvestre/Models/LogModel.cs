using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace San_Silvestre.Models
{
    public class LogModel
    {
        [Display(Name = "Show logs between")]
        public string RangeDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}