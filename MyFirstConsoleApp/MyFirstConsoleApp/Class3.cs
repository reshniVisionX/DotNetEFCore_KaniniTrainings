class Employees
{
    int age;
    String name;
    String country;

    public Employees(int age, String name, String country)
    {
        this.name = name;
        this.age = age;
        this.country = country;
    }
    public void display()
    {
        Console.WriteLine("Welcome " + name + " your age is  " + age + " from " + country);
    }
}

