using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Project
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string? firstName;
        [ObservableProperty]
        public string? lastName;
        [ObservableProperty]
        public int age;
        [ObservableProperty]
        public int gpa;
        [ObservableProperty]
        public string? dateofBirth;

        [ObservableProperty]
        public BitmapImage image;

        [ObservableProperty]
        public Student student = new Student();

        [ObservableProperty]
        public ObservableCollection<Student> studentsList = new ObservableCollection<Student>();



        [RelayCommand]
        public void CreateStudent()
        {
            
            Student temp = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                GPA = gpa,
                DateofBirth = dateofBirth,
                Image = image
            };
            StudentsList.Add(temp);
            var studentsList2 = StudentsList.ToList();
            StudentsList=new ObservableCollection<Student>(studentsList2);
        }

        [RelayCommand]
        public void OpenWindow()
        {  
            var window = new AddStudent(this);
            window.Show();
        }

        [RelayCommand]
        public void RemoveStudent(Student student3)
        {
            StudentsList.Remove(student3);
        }

        [RelayCommand]
        public void EditStudent(Student student2)
        {
            student = student2;
            var window=new EditStudent(this);
            window.Show();
            
        }

        [RelayCommand]
        public void SaveEditedDetails()
        {
            student.FirstName = firstName;
            student.LastName = lastName;
            student.Age = age;
            student.DateofBirth = dateofBirth;
            student.GPA = gpa;
            student.Image = image;
            var studentsList2 = StudentsList.ToList();
            StudentsList = new ObservableCollection<Student>(studentsList2);
            
        }

        [RelayCommand]
        public void AddImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(dialog.FileName));

            }
        }
        public MainWindowVM()
        {
            
            Student std1 = new Student()
            {
                FirstName = "ahamed",
                LastName = "minhaj",
                Age = 23,
                Image = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative)),
                DateofBirth = "1998/10/22",
                GPA = 3.2


            };


            BitmapImage bitmapImage = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            StudentsList.Add(new Student("Mohamed","Arshad",23,"2000/5/2",bitmapImage,3.4));
            StudentsList.Add(std1);
            Student std2 = new Student()
            {
                FirstName = "Tom",
                LastName = "Brown",
                Age = 24,
                Image = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative)),
                DateofBirth = "1999/08/22",
                GPA = 3.7
            };
            StudentsList.Add(std2);


        }
    }
}
