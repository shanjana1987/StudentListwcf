using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StudentListwcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static readonly List<Student> Students = new List<Student>();
        private static int _nextId = 1;
        public IEnumerable<Student> GetAllStudents()
        {
            return Students;
        }

        public Student AddStudent(string name, int semester)
        {
            Student student = new Student { Id = _nextId++, Name = name, Semester = semester };
            Students.Add(student);
            return student;
        }

        public Student FindStudentById(int id)
        {
            return Students.FirstOrDefault(student => student.Id == id);
        }

        public IEnumerable<Student> FindStudentByName(string name)
        {
            return Students.FindAll(student => student.Name.Contains(name));
        }

        public bool RemoveStudent(int id)
        {
            Student toBeRemove = FindStudentById(id);
            if (toBeRemove == null) return false;
            return Students.Remove(toBeRemove);
        }

        public bool EditStudent(int id, string name, int semester)
        {
            Student student = FindStudentById(id);
            if (student == null) return false;
            student.Name = name;
            student.Id = id;
            return true;
        }

        public void Clear()
        {
            Students.Clear();
            _nextId = 1;
        }
    }
}
