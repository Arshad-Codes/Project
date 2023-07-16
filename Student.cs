using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Project
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public string DateofBirth { get; set; }
        public BitmapImage Image { get; set; }
        public String Path
        {
            get { return $"/Images/{Image}"; }
        }
        public Student(string firstName, string lastName, int age, string date, BitmapImage image, double gpa)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            DateofBirth = date;
            Image = image;
            GPA = gpa;
        }
        public Student()
        {

        }
    }
    }
