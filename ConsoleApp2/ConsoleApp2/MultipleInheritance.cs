using System;

public interface IMobile
{
    void MakeCall();
    void SendMessage();
    void TakePicture()
    {
        Console.WriteLine("Picture taken using imobile");
    }
}
public interface Android
{
    void MakeCall();
    void SendMessage();
    void Display();

    void TakePicture()
    {
        Console.WriteLine("Picture taken using android");
    }
}

public abstract class PhoneBase
{
    protected long phno;
    protected string name;
    protected int pin;

    protected PhoneBase(long phno, string name, int pin)
    {
        this.phno = phno;
        this.name = name;
        this.pin = pin;
    }

    public void display()
    {
        Console.WriteLine("Name " + name);
        Console.WriteLine("Phone number " + phno);
        Console.WriteLine("Pin " + pin);
    }
}

public class SamsungA11 : PhoneBase, IMobile, Android
{
    public SamsungA11(long phno, string name, int pin)
        : base(phno, name, pin)
    {
        Console.WriteLine("Samsung constructor");
    }
    public void MakeCall() 
    {
        Console.WriteLine($"Make call for {name} using samsung");
    }

    public void SendMessage()
    {
        Console.WriteLine($"Send message to {name} using samsung");
    }

    public void Display()
    {
        Console.WriteLine("This is a SamsungA12 phone");
    }
}

public class Motorolas : PhoneBase, IMobile, Android
{
    public Motorolas(long phno, string name, int pin)
        : base(phno, name, pin)
    {
        Console.WriteLine("Motorola constructor");
    }

    public void MakeCall()
    {
        throw new NotImplementedException();
    }

    public void SendMessage()
    {
        throw new NotImplementedException();
    }

    public void Display()
    {
        Console.WriteLine("This is a Motorola phone");
    }
}

