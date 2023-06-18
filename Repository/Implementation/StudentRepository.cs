using StudentsRM.Entities;
using StudentsRM.Repository.Interface;
using StudentsRM.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace StudentsRM.Repository.Implementation
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentsRMContext context) : base(context)
        {
            
        }

        public List<Course> GetStudentByCourseId(string courseId)
        {
            var students = _context.Courses
            .Where(c => c.Id.Equals(courseId))
            .ToList();
            return students;
        }

        public Student GetStudentResult(Expression<Func<Student, bool>> expression)
        {
            var student = _context.Students
                .Include(s => s.Course)
                .Include(s => s.Results)
                .SingleOrDefault(expression);

            return student;
        }

        public Student GetStudent(Expression<Func<Student, bool>> expression)
        {
            var student = _context.Students
                .Include(s => s.Course)
                .SingleOrDefault(expression);

            return student;
        }
    }
}