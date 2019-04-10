using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Subdivision
    {
        public int SubdivisionId { get; set; }

        [Required]
        [StringLength(64)]
        public string SubdivisionName { get; set; }
    }
}
