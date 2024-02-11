using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public class DtoTypeRealStat
    {

        public int id_type { get; set; }
        [Required]
        public string type_ar { get; set; }
        public string type_fr { get; set; }
    }
}
