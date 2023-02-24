namespace System;

interface IPersonService
{
    int calculateAge();
    decimal calculateSalary();
    string[] getAddresses();
    bool checkSalary();
}
interface IStudentService: IPersonService
{
    double calculateGPA();
    Course[] getCourses();
    string[] getGrades();
}

interface IInstructorService: IPersonService
{
    Department getDepartment();
    int calculateYear();
}

interface ICourseService
{
    Student[] getStudents();
}

interface IDepartmentService
{
    Instructor getInstuctor();
    decimal getBudget();
    Course[] getCourse();
}

abstract class Person: IPersonService
{
    private int id;
    private string name;
    private int age;
    private string[] addresses;
    protected decimal salary;

    public Person(int id, string name, int age, string[] addresses, decimal salary)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.addresses = addresses;
        this.salary = salary;
    }
    
    public int calculateAge()
    {
        return age;
    }

    public abstract decimal calculateSalary();

    public string[] getAddresses()
    {
        return addresses;
    }

    public bool checkSalary()
    {
        if (salary >= 0)
        {
            return true;
        }
        {
            return false;
        }
    }
}

class Student : Person, IStudentService
{
    private Course[] courses;
    private string[] grades;
    
    public Student(int id, string name, int age, string[] addresses, decimal salary, 
        Course[] courses, string[] grades): base(id, name,age,addresses,salary)
    {
        this.courses = courses;
        this.grades = grades;
    }
    public double calculateGPA()
    {
        double totalGradePoints = 0;
        double totalCredits = 0;

        for (int i = 0; i < grades.Length; i++)
        {
            string grade = grades[i];
            double credits = 3; // assuming all courses are worth 3 credits

            if (grade == "A")
            {
                totalGradePoints += 4 * credits;
            }
            else if (grade == "B")
            {
                totalGradePoints += 3 * credits;
            }
            else if (grade == "C")
            {
                totalGradePoints += 2 * credits;
            }
            else if (grade == "D")
            {
                totalGradePoints += 1 * credits;
            }

            totalCredits += credits;
        }

        return totalGradePoints / totalCredits;
    }

    public Course[] getCourses()
    {
        return courses;
    }

    public string[] getGrades()
    {
        return grades;
    }

    public override decimal calculateSalary()
    {
        return 0; //students have no income
    }
}

class Instructor: Person, IInstructorService
{
    private Department department;
    private DateTime joinTime;
    public Instructor(int id, string name, int age, string[] addresses, decimal salary, 
        Department department, DateTime joinTime) : base(id, name, age, addresses, salary)
    {
        this.department = department;
        this.joinTime = joinTime;
    }

    public override decimal calculateSalary()
    {
        int yearsOfExperience = calculateYear();
        decimal bonusSalary = 0;

        if (yearsOfExperience >= 5)
        {
            bonusSalary = salary * (decimal)0.05;
        }
        else if (yearsOfExperience >= 2)
        {
            bonusSalary = salary * (decimal)0.02;
        }

        return bonusSalary;
    }

    public Department getDepartment()
    {
        return department;
    }

    public int calculateYear()
    {
        return DateTime.Now.Year-joinTime.Year;
    }
}
class Course: ICourseService
{
    private Student[] Students;
    
    public Student[] getStudents()
    {
        return Students;
    }
}

class Department : IDepartmentService
{
    private Instructor instructor;
    private Course[] Courses;
    private decimal budget;
    
    public Instructor getInstuctor()
    {
        return instructor;
    }

    public decimal getBudget()
    {
        return budget;
    }

    public Course[] getCourse()
    {
        return Courses;
    }
}

