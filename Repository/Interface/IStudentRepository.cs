using System.Linq.Expressions;
using StudentsRM.Entities;

namespace StudentsRM.Repository.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Course> GetStudentByCourseId(string courseId);
        Student GetStudentResult(Expression<Func<Student, bool>> expression);
        Student GetStudent(Expression<Func<Student, bool>> expression);
    }
}