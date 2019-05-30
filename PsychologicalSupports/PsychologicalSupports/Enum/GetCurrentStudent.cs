using PsychologicalSupports.Models;

namespace PsychologicalSupports.Enum
{
    public class GetCurrentStudent
    {
        private readonly PsychologicalSupportsEntities _psychologicalSupportsContext = new PsychologicalSupportsEntities();

        public string GetStudentId(int Id)
        {
            Student student = _psychologicalSupportsContext.Students.Find(Id);
            return student.FIO;
        }
    }
}