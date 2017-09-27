using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentListwcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListwcf.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        //  private readonly IService _service = new Service();
        private readonly IService1 _service = new Service1();

        [TestCleanup]
        public void Clean()
        {
            _service.Clear();
        }

        [TestMethod]
        public void GetAllStudentsTest()
        {
            Student st = _service.AddStudent("Anders", 1);
            Student st2 = _service.AddStudent("Bent", 4);
            IEnumerable<Student> students = _service.GetAllStudents();
            Assert.AreEqual(2, students.Count());
        }

        [TestMethod]
        public void AddStudentTest()
        {
            Student st = _service.AddStudent("Anders", 1);
            //Assert.AreEqual(1, st.Id);
            Assert.AreEqual("Anders", st.Name);
            Assert.AreEqual(1, st.Semester);
        }

        [TestMethod]
        public void FindStudentByIdTest()
        {
            Student st = _service.AddStudent("Anders", 1);
            Assert.AreEqual(1, _service.GetAllStudents().Count());
            Student st2 = _service.FindStudentById(st.Id);
            Assert.AreEqual(st, st2);
        }

        [TestMethod]
        public void FindStudentByNameTest()
        {
            Student st = _service.AddStudent("Anders", 1);
            Student st2 = _service.AddStudent("Bent", 4);
            IEnumerable<Student> eStudents = _service.FindStudentByName("e");
            Assert.AreEqual(2, eStudents.Count());
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            Student st = _service.AddStudent("Anders", 1);
            Student st2 = _service.AddStudent("Bent", 4);
            bool removed = _service.RemoveStudent(st.Id);
            Assert.IsTrue(removed);
            Assert.AreEqual(1, _service.GetAllStudents().Count());

            removed = _service.RemoveStudent(44);
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void EditStudentTest()
        {
            Student st = _service.AddStudent("Anders", 1);
            bool changed = _service.EditStudent(st.Id, "Anders B", 1);
            Assert.IsTrue(changed);
            Student s = _service.FindStudentById(st.Id);
            Assert.AreEqual("Anders B", s.Name);

            changed = _service.EditStudent(42, "Peter", 6);
            Assert.IsFalse(changed);
        }

    }
}