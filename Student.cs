using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLabor10
{
    namespace laba99
    {
        public class Student: IInit
        {
            int age;
            string name;
            double gpa;
            private static int objectCount = 0;
            Random rnd = new Random();

            public int Age
            {
                get => age;
                set
                {
                    if (value < 18)
                    {
                        Console.WriteLine("Ошибка: возраст должен быть в диапазоне от 18 до 22");
                    }
                    else if (value > 22)
                    {
                        Console.WriteLine("Ошибка: возраст должен быть в диапазоне от 18 до 22");
                    }
                    else
                    {
                        age = value;
                    }
                }
            }

            public string Name
            {
                get => name;
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        name = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: имя не может быть пустым");
                    }
                }
            }

            public double GPA
            {
                get => gpa;
                set
                {
                    if (value >= 0 && value <= 10)
                    {
                        gpa = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: значение GPA может принимать значения от 0 до 10");
                    }
                }
            }

            public Student()// конструктор без параметров
            {
                Age = 18;
                GPA = 0;
                Name = "Имя отсутствует";
                objectCount++;

            }

            public Student(string n, int a, double g)// конструктор с параметрами
            {
                Name = n;
                Age = a;
                GPA = g;
                objectCount++;

            }

            public Student(Student s)// конструктор копирования
            {
                this.name = s.name;
                this.age = s.age;
                this.gpa = s.gpa;
                objectCount++;

            }
            public void ShowVirtual()
            {
                Console.WriteLine($"Имя студента: {this.name}, возраст студента: {this.age}, GPA студента: {this.gpa}");
            }

            public static void ShowCount()
            {
                Console.WriteLine($"{objectCount} студентов создано");
            }


            public string CompareTo(Student otherStudent)
            {
                string comparisonResult = "";

                if (this.Age < otherStudent.Age)
                    comparisonResult += $"{this.Name} младше, чем {otherStudent.Name}. ";
                else if (this.Age > otherStudent.Age)
                    comparisonResult += $"{this.Name} старше, чем {otherStudent.Name}. ";
                else
                    comparisonResult += $"{this.Name} и {otherStudent.Name} ровесники. ";

                if (this.GPA > otherStudent.GPA)
                    comparisonResult += $"\nGPA {this.Name} выше, чем GPA {otherStudent.Name}.";
                else if (this.GPA < otherStudent.GPA)
                    comparisonResult += $"\nGPA {this.Name} ниже, чем GPA {otherStudent.Name}.";
                else
                    comparisonResult += $"\nGPA {this.Name} равен GPA {otherStudent.Name}.";

                return comparisonResult;
            }
            public static string CompareStudents(Student s1, Student s2)
            {
                string comparisonResult = "";

                if (s1.Age < s2.Age)
                    comparisonResult += $"{s1.Name} младше, чем {s2.Name}. ";
                else if (s1.Age > s2.Age)
                    comparisonResult += $"{s1.Name} старше, чем {s2.Name}. ";
                else
                    comparisonResult += $"{s1.Name} и {s2.Name} ровесники. ";

                if (s1.GPA > s2.GPA)
                    comparisonResult += $"\nGPA {s1.Name} выше, чем GPA {s2.Name}.";
                else if (s1.GPA < s2.GPA)
                    comparisonResult += $"\nGPA {s1.Name} ниже, чем GPA {s2.Name}.";
                else
                    comparisonResult += $"\nGPA {s1.Name} равен GPA {s2.Name}.";

                return comparisonResult;
            }

            public static Student operator ~(Student s)
            {
                string newname = s.name.ToLower();
                if (!string.IsNullOrEmpty(newname))
                {
                    newname = char.ToUpper(newname[0]) + newname.Substring(1);
                }

                return new Student(newname, s.age, s.gpa);
            }
            public static Student operator ++(Student s)
            {
                Student newStudent = new Student(s.Name, s.Age + 1, s.gpa);
                return newStudent;
            }
            public static explicit operator int(Student s)
            {
                int age = s.Age;
                int course = 0;

                if (age >= 18 && age < 19)
                {
                    course = 1;
                }
                else if (age > 19 && age <= 20)
                {
                    course = 2;
                }
                else if (age > 20 && age <= 21)
                {
                    course = 3;
                }
                else if (age > 21 && age <= 22)
                {
                    course = 4;
                }
                else if (age > 22)
                {
                    course = -1;
                }

                return course;
            }
            public static implicit operator bool(Student s)
            {
                return s.GPA < 6;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Student otherStudent = (Student)obj;
                return name == otherStudent.name && age == otherStudent.age && gpa == otherStudent.gpa;
            }
            public static Student operator %(Student s, string newName)
            {
                return new Student(newName, s.Age, s.GPA);
            }
            public static Student
            operator -(Student s, double d)
            {
                double newGPA = s.GPA - d;
                newGPA = Math.Round(newGPA, 1); // Округляем до одной цифры после запятой

                if (newGPA < 0)
                {
                    return s;
                }

                Student newStudent = new Student(s.Name, s.Age, newGPA);
                return newStudent;
            }
           

            public void Init()
            {
                Console.WriteLine("Введите фамилию студента:");
                string name = Console.ReadLine();
                if (name != null)
                {
                    Name = name;
                }
                else
                    Name = "No name";

                Console.WriteLine("Введите возраст студента:");
                int age = int.Parse(Console.ReadLine());
                Age = age;

                Console.WriteLine("Введите gpa студента:");
                double gpa = double.Parse(Console.ReadLine());
                GPA = gpa;
            }

            public void RandomInit()
            {
                string[] surnames = { "Иванов", "Петров", "Сидоров", "Степанов", "Данилов" };               

                Name = surnames[rnd.Next(surnames.Length)];
                Age = rnd.Next(18, 23);
                GPA = rnd.Next(0, 10);

            }

            public void Show()
            {
                Console.WriteLine($"Имя студента: {Name}, возраст студента: {Age}, GPA студента: {GPA}");
            }
            public override string ToString()
            {
                return $"Имя: {Name}, Возраст: {Age}, GPA: {GPA}";
            }
        }
    }
}

