using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM._BE
{
    public class Manager
    {
        [Key]
        public int Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
