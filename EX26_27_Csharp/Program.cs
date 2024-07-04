using System;
using System.Collections.Generic;
using System.Text;

namespace EX26_27
{
    // a.Khai báo interface KPI
    public interface KPI
    {
        double CalculateKPI();
    }

    // b. Lớp Person trừu tượng
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract override string ToString();
    }

    // b. Lớp Student kế thừa từ Person và cài đặt interface KPI
    public class Student : Person, KPI
    {
        public string Major { get; set; }
        public double GPA { get; set; }

        public Student(string name, int age, string major, double gpa) : base(name, age)
        {
            Major = major;
            GPA = gpa;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Major: {Major}, GPA: {GPA}";
        }

        public double CalculateKPI()
        {
            return GPA; 
        }
    }

    // d. Lớp Teacher kế thừa từ Person và cài đặt interface KPI
    public class Teacher : Person, KPI
    {
        public string Major { get; set; }
        public int Publications { get; set; }

        public Teacher(string name, int age, int publications) : base(name, age)
        {
            Publications = publications;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Publications: {Publications}";
        }

        public double CalculateKPI()
        {
            return 1.5 * Publications; // Điểm KPI của giáo viên là 1.5 lần số lượng bài báo
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // e. Khai báo và cấp phát đối tượng Student và Teacher
            Student student = new Student("Chu Mạnh Cường", 19, "CNTT&TT", 3.8);
            Teacher teacher = new Teacher("Trần Tiến Dũng", 38, 5);

            // Hiển thị thông tin và KPI của Student và Teacher
            Console.WriteLine("Student:");
            Console.WriteLine(student.ToString());
            Console.WriteLine($"KPI: {student.CalculateKPI()}");

            Console.WriteLine("\nTeacher:");
            Console.WriteLine(teacher.ToString());
            Console.WriteLine($"KPI: {teacher.CalculateKPI()}");
        }
    }
}