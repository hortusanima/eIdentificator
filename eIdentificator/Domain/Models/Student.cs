using System;

namespace eIdentificator.Domain
{
    public class Student
    {
        public string StudentId {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Year { get; set; }
        public string Level { get; set; }
        public string Department { get; set; }
        public bool Identified { get; set; }
        public DateTime? Identification_Date { get; set; }
    }
}
