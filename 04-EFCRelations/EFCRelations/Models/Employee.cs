using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCRelations.Models
{

    [Index("Egn", IsUnique = true, Name = "IXEgn")]

    public class Employee
    {
        public Employee()
        {
            this.ClubParticipations = new HashSet<EmployeeInClub>();
        }

        [Key]
        public int Eid { get; set; }

        [MaxLength(25)]
        [Required]
        public string Egn { get; set; }

        [Column("FN")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartWorkDate { get; set; }

        public decimal? Salary { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }


        public ICollection<EmployeeInClub> ClubParticipations { get; set; }
    }
}
