using System;
using System.Collections.Generic;
using System.Text;

namespace EFCRelations.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
