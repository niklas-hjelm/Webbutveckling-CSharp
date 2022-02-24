using DatabaseFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstDemo.DAL
{
    public class HeroSchoolStorage
    {

        private readonly HeroSchoolContext _context;

        public HeroSchoolStorage()
        {
            _context = new HeroSchoolContext();
        }

        public string CreateStudent(Student student)
        {
            if (student.FirstName is null || student.LastName is null)
            {
                return "First- AND Last-Name must have values!";
            }
            
            if (_context.Students.Any(s => s.Id == student.Id))
            {
                return "Id already exists in database!";
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return "All is well!";
        }

        public string CreateCourse(Course course)
        {
            if (course.Name is null || course.Points == 0)
            {
                return "Name AND Points must have values!";
            }
            
            if (_context.Courses.Any(c => c.Id == course.Id))
            {
                return "Id already exists in database!";
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return "All is well!";
        }

        public List<Student> GetAllStudents()
        {
            var test = _context.Students.Where(s => true).ToList();

            foreach (var student in test)
            {
                _context.Entry(student).Collection(s=>s.Courses).Load();
            }

            return test;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.Where(_ => true).ToList();
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public Course? GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Update(object thingToUpdate, string table)
        {

        }

        public void Delete(int id, string table)
        {

        }
    }
}
