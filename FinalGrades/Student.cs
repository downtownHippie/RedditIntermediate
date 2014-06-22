using System;
using System.Collections.Generic;

namespace FinalGrades
{
    public class Student : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FinalGrade { get; set; }
        public string FinalLetter { get; set; }
        public List<int> Grades = new List<int>();

        public Student(string firstName, string lastName, params int[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            foreach (int grade in grades)
                Grades.Add(grade);
            calculateFinalGrade();
            calculateFinalLetter();
        }

        private void calculateFinalLetter()
        {
            if (FinalGrade > 93)
                FinalLetter = "A";
            else if (FinalGrade >= 90)
                FinalLetter = "A-";
            else if (FinalGrade >= 87)
                FinalLetter = "B+";
            else if (FinalGrade > 83)
                FinalLetter = "B";
            else if (FinalGrade >= 80)
                FinalLetter = "B-";
            else if (FinalGrade >= 77)
                FinalLetter = "C+";
            else if (FinalGrade > 73)
                FinalLetter = "C";
            else if (FinalGrade >= 70)
                FinalLetter = "C-";
            else if (FinalGrade >= 67)
                FinalLetter = "D+";
            else if (FinalGrade > 63)
                FinalLetter = "D";
            else if (FinalGrade >= 60)
                FinalLetter = "D-";
            else
                FinalLetter = "F";
        }

        private void calculateFinalGrade()
        {
            double sum = 0.0;
            foreach (int grade in Grades)
                sum += grade;
            FinalGrade = (int)Math.Round(sum / Grades.Count);
        }

        // sort highest grades first
        public int CompareTo(object obj)
        {
            Student s = (Student)obj;
            return s.FinalGrade - this.FinalGrade;
        }
    }
}
