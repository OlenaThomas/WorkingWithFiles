using System;
using System.Collections.Generic;
using System.Linq;
using TeacherStudentsLibrary;
using WorkingWithXMLJSON.DataLayers;
using WorkingWithXMLJSON.CollectionToXML;

namespace WorkingWithXMLJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string STUDENTS_XML_FILE_NAME = "../students.xml";

            const string STUDENTS_JSON_FILE_NAME = "../students.json";

            #region ---== XML ==---

            TeacherStudentsDataModel model = new TeacherStudentsDataModel();
            XMLDataLayer<List<Student>> xMLDataLayer = new XMLDataLayer<List<Student>>();

            //Students
            xMLDataLayer.Write(STUDENTS_XML_FILE_NAME, model.Students.ToList());

            List<Student> students = xMLDataLayer.Read(STUDENTS_XML_FILE_NAME);

            Console.WriteLine("Students");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            //-----------------------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Magenta;
            // Serialize Collection

            Students students_col = new Students();

            foreach (Student student in students)
            {
                students_col.Add(student);
            }

            XMLDataLayerCollection<Students> xMLDataLayerCollection = new XMLDataLayerCollection<Students>();
            xMLDataLayerCollection.Write("../students_collection.xml", students_col);

            Students studentsCollection = xMLDataLayerCollection.Read("../students_collection.xml");

            Console.WriteLine("studentsCollection");
            for (int i = 0; i < studentsCollection.Count; i++)
            {
                Console.WriteLine(students_col[i]);
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            #region ---== JSON ==---

            JSONDataLayer<Student> sONDataLayer = new JSONDataLayer<Student>();
            sONDataLayer.Write(STUDENTS_JSON_FILE_NAME, model.Students);

            var result = sONDataLayer.Read(STUDENTS_JSON_FILE_NAME);

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

            #endregion

            Console.WriteLine("Done");

            Console.ReadKey();
        }


    }
}
