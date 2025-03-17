using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wk8Ex3
{
    internal class Program
    {
        //create a class for student
        class Student
        {
            public string Name { get; set; }
            public int Grade { get; set; }

            public Student()
            {

            }
            //constructor
            public Student(string name, int grade)
            {
                Name = name;
                Grade = grade;
            }
        }

        //method to read CSV file and store the data in a list of objects
        static List<Student> ReadCsv(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            //declare a string variable to hold each line of the file
            string line = string.Empty;

            //create a list of student objects
            List<Student> students = new List<Student>();

            //enter loop to read file until there are no more lines
            while ((line = reader.ReadLine()) != null)
            {
                //check if the line is empty or contains the header "Age"
                if (line.Contains("Age"))
                {
                    //skip the header line
                    continue;
                }
                else
                {
                    //split the line by comma
                    string[] words = line.Split(',');

                    string name = words[0];
                    //convert the second column to an integer for age
                    int grade = Convert.ToInt32(words[1]);

                    //create a new student object and add it to the list
                    Student student = new Student(name, grade);
                    students.Add(student);
                }
            }
            //close the reader
            reader.Close();
            //return the list of students for the main method
            return students;

        }
        static void Main(string[] args)
        {
            //string variable for file path
            string fileName = @"D:\Students.csv";

            //create list of student objects\
            List<Student> students = new List<Student>();

            //call method to separate the data from CSV file by comma
            List<Student> seperatedStudents = new List <Student>(ReadCsv(fileName));

            //loop through the list of students and print their names and ages
            foreach (Student student in seperatedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            }

            //wait for user input before closing
            Console.ReadLine();
        }

    }
}
