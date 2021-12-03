using System;
using System.Collections.Generic;
using System.Text;

namespace EFCRelations.Models
{
    public class Club
    {
        public Club()
        {
            this.Employees = new HashSet<EmployeeInClub>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeInClub> Employees { get; set; }
    }
}
