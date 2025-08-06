using System.Diagnostics.Metrics;
using System.Transactions;
using System.Xml.Linq;

class Employee
{
   public int age;
   public String name;
   public String country;
    static String Dept = "Manager";

    static Employee(){
        Console.WriteLine("Static members initialization");
        Dept = "Senior Manager";
    }
    public Employee()
    {
        Console.WriteLine("This is Employee default constructor");
    }
    public Employee(String country,int age,String name) 
    {
        this.name = name;
        this.age = age;
        this.country = country;
    }
    public virtual void display()
    {
        Console.WriteLine("Welcome " + name + " your age is  " + age+" from "+country+" Working as "+Dept);
    }
}

class PermanentEmployee : Employee
{
    int id;
    long phone;
    int salary;
    

    public PermanentEmployee(int id, long phone, int salary, string country, int age, string name) :  base(country, age, name)
    {
        this.id = id;
        this.phone = phone;
        this.salary = salary;
   
    }
    public override void display()
    {
        base.display();
        Console.WriteLine("Id : " + id + " phone " + phone + " salary " + salary);
    }
}

class TemporaryEmployee : Employee
{
    int id;
    long phone;
    int salary;

    public TemporaryEmployee(int id, long phone, int salary,string country, int age, string name) : base(country, age, name)
    {
        this.id = id;
        this.phone = phone;
        this.salary = salary;
    }
    public TemporaryEmployee(TemporaryEmployee te) : base(te.country, te.age, te.name)
    {
        id = te.id;
        phone = te.phone;
        salary = te.salary;
    }
    public override void display()
    {
        base.display();
        Console.WriteLine("Id : " + id + " phone " + phone + " salary " + salary);
    }
}


