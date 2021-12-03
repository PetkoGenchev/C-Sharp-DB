using System;
using System.Collections.Generic;
using System.Text;

namespace EFCRelations.Models
{
    public class EmployeeInClub
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int ClubId { get; set; }

        public Club Club { get; set; }

        public DateTime JoinDate { get; set; }

        
    }
}
