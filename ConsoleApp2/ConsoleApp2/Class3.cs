using System;
internal class Arrays
{
  
    public void ReadArray()
    {
        int n, m;
        Console.WriteLine("Enter the number of rows: ");
        n = int.Parse(Console.ReadLine());
        int[][] arr = new int[n][];
        int sum = 0;
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter the count of {i+1} ");
            m = int.Parse(Console.ReadLine());
            arr[i]=new int[m];
            sum = 0;
            Console.WriteLine($"Enter the {i+1} row values ");
            for(int j = 0; j < m; j++)
            {
                arr[i][j]=int.Parse(Console.ReadLine());
                sum += arr[i][j];
            }
            Console.WriteLine($"The total of team {i+1} is {sum}");
        }
    }
          
}

