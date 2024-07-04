using System;
using System.Collections.Generic;
using System.Text;

// Abstract class Person
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        protected string BankAccount { get; set; }

        // Constructor
        public Person(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        // Abstract method
        public abstract string GetRole();
    }

    // Interface KPIEvaluator
    public interface KPIEvaluator
    {
        double CalculateKPI();
    }

    // Class TeachingAssistant
    public class TeachingAssistant : Person, KPIEvaluator
    {
        public string EmployeeID { get; set; }
        private int numberOfCourses;

        // Constructor
        public TeachingAssistant(string name, int age, string gender, string employeeID, int numberOfCourses)
            : base(name, age, gender)
        {
            EmployeeID = employeeID;
            this.numberOfCourses = numberOfCourses;
        }

        // Overriding GetRole method
        public override string GetRole()
        {
            return "Teaching Assistant";
        }

        // Implementing CalculateKPI method
        public double CalculateKPI()
        {
            return numberOfCourses * 5;
        }
    }

    // Class Lecturer
    public class Lecturer : Person, KPIEvaluator
    {
        public string EmployeeID { get; set; }
        private int numberOfPublications;

        // Constructor
        public Lecturer(string name, int age, string gender, string employeeID, int numberOfPublications)
            : base(name, age, gender)
        {
            EmployeeID = employeeID;
            this.numberOfPublications = numberOfPublications;
        }

        // Overriding GetRole method
        public override string GetRole()
        {
            return "Lecturer";
        }

        // Implementing CalculateKPI method
        public double CalculateKPI()
        {
            return numberOfPublications * 7;
        }
    }

    // Class Professor
    public sealed class Professor : Lecturer
    {
        public static int CountProfessors = 0;
        private int numberOfProjects;

        // Constructor
        public Professor(string name, int age, string gender, string employeeID, int numberOfPublications, int numberOfProjects)
            : base(name, age, gender, employeeID, numberOfPublications)
        {
            this.numberOfProjects = numberOfProjects;
            CountProfessors++;
        }

        // Overriding GetRole method
        public override string GetRole()
        {
            return "Professor";
        }

        // Implementing CalculateKPI method
        public new double CalculateKPI()
        {
            return base.CalculateKPI() + numberOfProjects * 10; // Assume each project adds 10 points to the KPI
        }
    }
class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        // Test creating objects and displaying their information
        TeachingAssistant ta = new TeachingAssistant("Cường", 19, "Nam", "TA123", 6);
        Lecturer lecturer = new Lecturer("Đạt", 19, "Nam", "LE456", 6);
        Professor professor = new Professor("Huy", 19, "Nam", "PR789", 10, 6);

        PrintPersonInfo(ta);
        PrintPersonInfo(lecturer);
        PrintPersonInfo(professor);

        // Array of objects input and display
        int n = GetNumberOfObjects();
        Person[] people = new Person[n];

        // Input array of objects
        InputArray(people);

        // Display array of objects
        DisplayArray(people);

        // Display count of professors
        Console.WriteLine($"Tổng số lượng Giáo viên ( professor) : {Professor.CountProfessors}");
    }

    static void PrintPersonInfo(Person person)
    {
        if (person is KPIEvaluator kpiEvaluator)
        {
            Console.WriteLine($"{person.Name} is a {person.GetRole()} with KPI: {kpiEvaluator.CalculateKPI()}");
        }
    }

    static int GetNumberOfObjects()
    {
        int n;
        do
        {
            Console.Write("Nhập số lượng đối tượng (giữa 2 và 10): ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 10);

        return n;
    }

    static void InputArray(Person[] people)
    {
        for (int i = 0; i < people.Length; i++)
        {
            people[i] = InputPerson();
        }
    }

    static Person InputPerson()
    {
        while (true)
        {
            Console.Write("nhập loại đối tượng (ta, lec, gs): ");
            string type = Console.ReadLine().Trim().ToLower();

            Console.Write("Tên: ");
            string name = Console.ReadLine();

            Console.Write("Tuổi: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age, please enter again.");
                continue;
            }

            Console.Write("Giới tính: ");
            string gender = Console.ReadLine();

            Console.Write("employee ID: ");
            string employeeID = Console.ReadLine();

            switch (type)
            {
                case "ta":
                    Console.Write("số lượng khóa học được hỗ trợ : ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfCourses))
                    {
                        Console.WriteLine("Invalid number of courses, please enter again.");
                        continue;
                    }
                    return new TeachingAssistant(name, age, gender, employeeID, numberOfCourses);

                case "lec":
                    Console.Write("số lượng bài báo đã xuất bản : ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfPublications))
                    {
                        Console.WriteLine("Invalid number of publications, please enter again.");
                        continue;
                    }
                    return new Lecturer(name, age, gender, employeeID, numberOfPublications);

                case "gs":
                    Console.Write("số lượng bài báo đã xuất bản : ");
                    if (!int.TryParse(Console.ReadLine(), out int numPublications))
                    {
                        Console.WriteLine("Invalid number of publications, please enter again.");
                        continue;
                    }
                    Console.Write("số lượng project đã chủ trì : ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfProjects))
                    {
                        Console.WriteLine("Invalid number of projects, please enter again.");
                        continue;
                    }
                    return new Professor(name, age, gender, employeeID, numPublications, numberOfProjects);

                default:
                    Console.WriteLine("Invalid type, please enter again.");
                    break;
            }
        }
    }

    static void DisplayArray(Person[] people)
    {
        foreach (var person in people)
        {
            PrintPersonInfo(person);
        }
    }
}