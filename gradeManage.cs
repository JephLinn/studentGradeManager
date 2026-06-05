using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public int ID { get; set; }
    public List<double> Grades { get; set; } = new List<double>();

    public double GetAverage()
    {
        if (Grades.Count == 0)
            return 0;

        return Grades.Average();
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== Student Grade Management System =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. View Student");
            Console.WriteLine("4. View All Students");
            Console.WriteLine("5. Remove Student");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddGrade();
                    break;
                case "3":
                    ViewStudent();
                    break;
                case "4":
                    ViewAllStudents();
                    break;
                case "5":
                    RemoveStudent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        Console.WriteLine("Exiting program...");
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student ID: ");
        string idInput = Console.ReadLine();

        if (int.TryParse(idInput, out int id))
        {
            students.Add(new Student { Name = name, ID = id });
            Console.WriteLine("Student added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID. Student not added.");
        }
    }

    static void AddGrade()
    {
        Console.Write("Enter student ID: ");
        string idInput = Console.ReadLine();

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student student = students.FirstOrDefault(s => s.ID == id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter grade: ");
        string gradeInput = Console.ReadLine();

        if (double.TryParse(gradeInput, out double grade))
        {
            student.Grades.Add(grade);
            Console.WriteLine("Grade added.");
        }
        else
        {
            Console.WriteLine("Invalid grade.");
        }
    }

    static void ViewStudent()
    {
        Console.Write("Enter student ID: ");
        string idInput = Console.ReadLine();

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student student = students.FirstOrDefault(s => s.ID == id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine($"\nName: {student.Name}");
        Console.WriteLine($"ID: {student.ID}");
        Console.WriteLine("Grades: " + (student.Grades.Count > 0 ? string.Join(", ", student.Grades) : "No grades yet"));
        Console.WriteLine($"Average: {student.GetAverage():0.00}");
    }

    static void ViewAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n===== All Students =====");

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} (ID: {student.ID}) - Average: {student.GetAverage():0.00}");
        }
    }

    static void RemoveStudent()
    {
        Console.Write("Enter student ID to remove: ");
        string idInput = Console.ReadLine();

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student student = students.FirstOrDefault(s => s.ID == id);

        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student removed.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
