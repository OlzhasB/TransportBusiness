using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Worker : Person
    {
        public int workerID;
        public DateTime employmentDate { get; set; }
        public string position { get; set; }
        public int salary { get; set; }

        public Worker(int personID, string firstname, string lastname, string patronymic,
        DateTime dateOfBirth, string iin, int workerID, DateTime employmentDate, string position,
        int salary) : base(personID, firstname, lastname, patronymic, dateOfBirth, iin)
        {
            this.workerID = workerID;
            this.employmentDate = employmentDate;
            this.position = position;
            this.salary = salary;
        }
    }
}
