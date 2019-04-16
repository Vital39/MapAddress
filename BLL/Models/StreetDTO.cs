using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class StreetDTO
    {
        [Key]
        public int StreetId { get; set; }

        [Required]
        [StringLength(128)]
        public string StreetName { get; set; }
    }
}
