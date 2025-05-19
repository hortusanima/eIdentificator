using System.Collections.Generic;

namespace eIdentificator.Domain.Interfaces
{
    public interface IStudentsRepository
    {
        List<Student> GetAllStudentsByFilters(string key, string godina, string vrsta, string smer);
        List<Student> GetIdentifiedStudents();
        int GetCountOfAllStudents();
        int GetCountOfStudentsByIdentifiedValue(bool isIdentified, string level);
        List<string> GetStudentDistinctFieldValues(string field, string referenceField, string refrenceValue);
        void UpdateStudentIdentifiedField(string index, bool isIdentified);
        void ResetStudentFieldValues(bool isForced);
    }
}
