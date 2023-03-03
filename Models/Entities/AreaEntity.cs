using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementSystem.Models.Entities
{
    public class AreaEntity
    {
        public int Id { get; set; }
        // Should be set to one of the following:
        // IT, HR, House Keeping Inside, House Keeping Outside
        public string Area { get; set; } = string.Empty;
    }
}
