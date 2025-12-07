using prac12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac12.Data
{
    public class RegInterestGroupViewModel
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public InterestGroupService InterestGroupService { get; set; }
        public InterestGroup? Current { get; set; }

        public DateTime? JoinedAt { get; set; }

    }
}
