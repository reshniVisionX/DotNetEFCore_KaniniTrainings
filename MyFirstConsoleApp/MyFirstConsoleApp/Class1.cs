internal class Marks
{
    public void Analyze(int eng, int math,ref int assign,out String grade)
    {
       int  om = eng + math;
        assign += 5;
       int  bm = om + assign;
        eng += 100;
        if (om >= 50)
        {
            grade = "Pass";
        }
        else
        {
            grade = "fail";
        }
    }
    public static void main(String[] args)
    {
        Marks s = new Marks();
        Console.WriteLine("Enter the eng ,math and assign marks ");
        int eng = Convert.ToInt32(Console.ReadLine());
        int math = Convert.ToInt32(Console.ReadLine());
        String grade;
        int assign = 10;
        s.Analyze(eng, math, ref assign,out grade);
        Console.WriteLine(eng + " " + math);
        Console.WriteLine(assign);
        Console.WriteLine(grade);
    }
}