using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AgencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsInternational { get; set; }
        public int UserId { get; set; }
    }
}
