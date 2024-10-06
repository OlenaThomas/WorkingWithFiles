using LogerLab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TeacherStudentsLibrary;
using WorkingWithFiles.DataLayers;
using WorkingWithFiles.Enums;
using WorkingWithFiles.Exceptions;
using WorkingWithFiles.Helpers;
using WorkingWithFiles.Services;

namespace WorkingWithFiles
{
    internal class Program
    {
        const string STUDENTS_FILE_NAME = "../students.txt";

        const string STUDENTS_FILE_NAME_1 = "../students_1.txt";
        const string TEACHERS_FILE_NAME_1 = "../teachers_1.txt";
        const string GROUPS_FILE_NAME_1 = "../groups_1.txt";

        const string GROUPS_FILE_NAME_CSV = "../groups.csv";
        const string STUDENTS_FILE_NAME_CSV = "../students.csv";

        const string LOGGER = "../logger.txt";

        static ILogger _logger = LoggerWithNLog.GetInstance();

        static void Main(string[] args)
        {
            TeacherStudentsDataModel model = new TeacherStudentsDataModel();

            #region ----== StreamWriter Write/ReadLine Generic ==----

            #region ----== TXT ==---

            //Students
            FileType fileType_1 = GetFileType(STUDENTS_FILE_NAME_1);

            if(fileType_1 != FileType.unknown)
            {
                IDataLayer <Student, StudentIO> txtData1 = 
                    DataLayerService<Student, StudentIO>.GetDataLayerCreator(fileType_1)?.Create();

                if(txtData1 != null)
                {
                    try
                    {
                        txtData1.Write(STUDENTS_FILE_NAME_1, model.Students);
                    }
                    catch(Exception e)
                    {

                        _logger.Error(e.Message);

                        Console.WriteLine("An input/output error occurred. Please contact your system administrator.");
                    }

                    try
                    {
                        IEnumerable<Student> studentsFromTXT1 = txtData1.Read(STUDENTS_FILE_NAME_1);
                        Show(studentsFromTXT1, "StudentsFromTXT1");
                    }
                    catch(ReadFromRecordException e)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < e.FieldCount; i++)
                        {
                            sb.Append(e[i]);
                        }

                        _logger.Error(e.Message, sb.ToString());
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine($"{ex.Message} Enter a new file name.");
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e.Message);

                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        _logger.Dispose();
                    }
                }
            }

            //Teachers
            TXTDataLayer<Teacher, TeacherIO> txtData2 = new TXTData<Teacher, TeacherIO>();

            txtData2.Write(TEACHERS_FILE_NAME_1, model.Teachers);

            IEnumerable<Teacher> teachersFromTXT1 = txtData2.Read(TEACHERS_FILE_NAME_1);

            Show(teachersFromTXT1, "TeachersFromTXT1");

            ////Groups
            TXTDataLayer<Group, GroupIO> txtData3 = new TXTData<Group, GroupIO>();

            txtData3.Write(GROUPS_FILE_NAME_1, model.Groups);

            IEnumerable<Group> groupsFromTXT1 = txtData3.Read(GROUPS_FILE_NAME_1);

            Show(groupsFromTXT1, "GroupsFromTXT1");

            #endregion

            #region ----== CSV ==---

            //Students
            TXTDataLayer<Student, StudentIO> csvData2 = new CSVData<Student, StudentIO>();

            csvData2.Write(STUDENTS_FILE_NAME_CSV, model.Students);

            IEnumerable<Student> studentsFromCsv1 = csvData2.Read(STUDENTS_FILE_NAME_CSV);

            Show(studentsFromCsv1, "StudentsFromCsv1");

            ////Groups csv
            TXTDataLayer<Group, GroupIO> csvData1 = new CSVData<Group, GroupIO>();

            csvData1.Write(GROUPS_FILE_NAME_CSV, model.Groups);

            IEnumerable<Group> groupsFromCsv1 = csvData1.Read(GROUPS_FILE_NAME_CSV);

            Show(groupsFromCsv1, "GroupsFromCsv1");

            #endregion

            #endregion


            #region ----== Binary ==----

            string binaryFileName = "../student.bin";

            BinaryDataLayer binaryData = new BinaryDataLayer();

            binaryData.Write(binaryFileName, model.Students);

            IEnumerable<Student> studentsFromBinary = binaryData.Read(binaryFileName);

            Show(studentsFromBinary, "StudentsFromBinary");

            #endregion


            #region ----== AppendAllText/ReadLines ==----

            Console.ForegroundColor = ConsoleColor.Cyan;

            File.AppendAllText(STUDENTS_FILE_NAME,
                new Student() { ID = 5, FirstName = "Alexandr", LastName = "Alexandrov", GroupID = 4, RecordBookNumber = 10202 } + "\n"
                + new Student() { ID = 6, FirstName = "Genadiy", LastName = "Belaev", GroupID = 1, RecordBookNumber = 10203 } + "\n");

            IEnumerable<string> data = File.ReadLines(STUDENTS_FILE_NAME);
            List<Student> studentsList_1 = new List<Student>();

            foreach (var item in data)
            {
                Student student = new Student();
                string[] parameters = item.Split();

                student.ID = int.Parse(parameters[0]);
                student.LastName = parameters[1];
                student.FirstName = parameters[2];
                student.GroupID = int.Parse(parameters[3]);
                student.RecordBookNumber = int.Parse(parameters[4]);

                studentsList_1.Add(student);
            }

            Show(studentsList_1);

            #endregion

            Console.Read();
        }

        public static void Show<T>(IEnumerable<T> source, string title = "") where T : TXTFiles
        {
            if (title.Length > 0)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine();

            foreach (var student in source)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
        }

        public static FileType GetFileType(string fileName)
        {
            FileType fileType = FileType.unknown;

            if (fileName.EndsWith(".csv"))
            {
                fileType = FileType.csv;
            }
            else if (fileName.EndsWith(".txt"))
            {
                fileType = FileType.txt;
            }

            return fileType;
        }

    }
}
