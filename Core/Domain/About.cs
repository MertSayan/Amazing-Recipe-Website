using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class About : Entity
    {
        public int AboutId { get; set; }
        public string Description { get; set; }
    }
}
