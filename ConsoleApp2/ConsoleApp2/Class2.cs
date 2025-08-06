abstract class Mobile
{
   public abstract void makeCall();
   public abstract void sendMessage();

   public void takePicture()
    {
        Console.WriteLine("Your photo is clicked");
    }
}

class SamsungA12 : Mobile
{
    private long phno;
    private String name;
    private int pin;

    public SamsungA12(long phno,String name,int pin)
    {
        this.phno = phno;
        this.name = name;
        this.pin = pin;
    }

    public override void makeCall()
    {
        Console.WriteLine($"Make call for {name} using samsung");
    }

    public override void sendMessage()
    {
        Console.WriteLine($"Send message to {name} using samsung");
    }

}

class Motorola : Mobile
{
    private long phno;
    private String name;
    private int pin;

    public Motorola(long phno, String name, int pin)
    {
        this.phno = phno;
        this.name = name;
        this.pin = pin;
    }
    public override void makeCall()
    {
        Console.WriteLine($"Make call for {name} using moto");
    }

    public override void sendMessage()
    {
        Console.WriteLine($"Send message to {name} using moto");
    }
}

sealed class Class2
{
        public void display()
        {
            Console.WriteLine("This is a sealed class");
        }
}

