using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    abstract class Person
    {
        public int personID { get; set; }
        public string firstname { get; set; } 
        public string lastname { get; set; }
        public string patronymic { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string iin { get; set; }

        public Person(int personID, string firstname, string lastname, string patronymic,
            DateTime dateOfBirth, string iin)
        {
            this.personID = personID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.patronymic = patronymic;
            this.dateOfBirth = dateOfBirth;
            this.iin = iin;
        }
        
    }
}
