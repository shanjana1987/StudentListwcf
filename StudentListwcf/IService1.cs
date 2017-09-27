using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StudentListwcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        IEnumerable<Student> GetAllStudents();

        [OperationContract]
        Student AddStudent(string name, int semester);

        [OperationContract]
        Student FindStudentById(int id);

        [OperationContract]
        IEnumerable<Student> FindStudentByName(string name);

        [OperationContract]
        bool RemoveStudent(int id);

        [OperationContract]
        bool EditStudent(int id, string name, int semester);

        /// <summary>
        /// Good for testing purposes
        /// </summary>
        [OperationContract]
        void Clear();
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Semester { get; set; }
    }
}

