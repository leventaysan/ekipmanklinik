using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneEkipman.Models
{
    public class Klinik
    {
        [Key]
        public int KlinikID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string KlinikName { get; set; }
    }
}
