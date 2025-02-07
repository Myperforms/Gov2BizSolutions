using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssessment.Infrastructure.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string JobTittle { get; set; } = string.Empty; 

        public decimal Salary { get; set; }
     
        public bool RemoteWorkStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
