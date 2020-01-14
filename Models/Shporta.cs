using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Models
{
    [Table("Shporta")]
    public class Shporta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Shporta { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string Id_UseriKlient { get; set; }

        [Required]
        public int Id_Piktura { get; set; }

        [Required]
        [DisplayName("Çmimi")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Çmimi duhet te jete brenda kufizave, 0 deri ne 18 shifrore")]
        public decimal Cmimi { get; set; }


        public bool Blerja { get; set; }
    }
}
