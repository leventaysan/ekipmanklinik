using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneEkipman.Models
{
    public class Ekipman
    {
        [Key]
        public int EkipmanID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string EkipmanName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EkipmanProcDate { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Adet Bilgisi Alanı Zorunludur. Adet Bilgisi Değeri en az 1 olmalıdır.")]

        public int EkipmanNumber { get; set; }
        [Column(TypeName = "nvarchar(20)")]

        public decimal EkipmanUnitPrice { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        
        public int EkipmanUsageRate { get; set; }
        [Required]
        public int KlinikID { get; set; }
    }
}
