using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PsychologicalSupports.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public byte NumberClass { get; set; }
        public char Class { get; set; }
        public DateTime AdmissionDate { get; set; }
        public ICollection<Test> Tests { get; set; }

        public Student()
        {
            Tests=new List<Test>();
        }
    }
}