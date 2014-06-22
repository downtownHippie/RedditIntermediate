using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FinalGrades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            FileStream inFile = new FileStream(args[0], FileMode.Open);
            StreamReader sReader = new StreamReader(inFile);
            while (!sReader.EndOfStream)
            {
                string line = sReader.ReadLine().Trim();
                string[] studentLine = Regex.Split(line, @"^(\w+\s*\w+)\s*,\s*(\w+\s*\w+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)$");
                // wanted better regex that gets any number of grades
                //  then
                // copy grades to int array to pass to constructor
                Student student = new Student(studentLine[1], studentLine[2], Convert.ToInt32(studentLine[3]), Convert.ToInt32(studentLine[4]), Convert.ToInt32(studentLine[5]), Convert.ToInt32(studentLine[6]), Convert.ToInt32(studentLine[7]));
                students.Add(student);
            }
            // close inputs
            sReader.Close(); inFile.Close();

            // students implements IComparable sorting reverse order of FinalGrade
            students.Sort();
            foreach (Student student in students)
            {
                Console.Write("{0} {1} ({2}%) ({3}):", student.LastName.PadRight(10), student.FirstName.PadRight(10), student.FinalGrade, student.FinalLetter);
                student.Grades.Sort(); student.Grades.Reverse();
                foreach (int grade in student.Grades)
                    Console.Write(" {0}", grade);
                Console.WriteLine();
            }

            // wait for input to close console window
            Console.ReadLine();
        }
    }
}
