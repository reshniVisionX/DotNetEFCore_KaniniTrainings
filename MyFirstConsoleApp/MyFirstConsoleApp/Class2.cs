using System;
public class Employee
{
    int id = 0;
    public Employee(int id)
    {
        this.id = id;
    }
    public virtual void ShowDept()
    {
        Console.WriteLine("Employee Department id "+id);
    }
    public void displayData(String name)
    {
        Console.WriteLine("Hii " + name);
    }
    public int displayData(String name,int id)
    {
        Console.WriteLine("Hii " + name+"  and id is "+id);
        return id;
    }
}
public class SeniorManager : Employee
{
    int id = 0;
    String name;
    public SeniorManager(int id, string name):base(id)
    {
        this.id = id;
        this.name = name;
    }

    public override void ShowDept()
    {
        Console.WriteLine("Senior Manager Department "+id+" name: "+name);
    }
}
public class Manager : SeniorManager
{
    int id = 0;
    String name;
    int age = 0;

    public Manager(int id, string name, int age):base(id,name)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }

    public override void ShowDept()
    {
        base.ShowDept();
        Console.WriteLine("Manager Department id "+id+" name: "+name+" age: "+age);
    }
}

