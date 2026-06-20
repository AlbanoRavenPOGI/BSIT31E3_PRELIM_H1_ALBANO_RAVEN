using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class Student
    {

        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            Name = name;
            Grade = grade;
        }
    }

    public class StudentManager
    {

        public List<Student> Students = new List<Student>();

        public void AddStudent(string name, double grade)
        {
            Students.Add(new Student(name, grade));
        }

        public double CalculateAverage()
        {
            if (Students.Count == 0) return 0;
            double sum = 0;
            foreach (var student in Students)
            {
        
                sum += student.Grade;
            }
            return sum / Students.Count;
        }

        public Student GetTopStudent()
        {
            if (Students.Count == 0) return null;
            Student top = Students[0];
            foreach (var student in Students)
            {
              
                if (student.Grade > top.Grade)
                {
                    top = student;
                }
            }
            return top;
        }
    }
}