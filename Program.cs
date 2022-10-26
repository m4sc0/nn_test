using System.Threading;

namespace neuraltest;
class Program
{
    public static double lr = 1;
    public static double bias = 1;
    public static double outputP;
    public static List<double> weights = new List<double>();
    public static int gen = 0;

    static void Perceptron(double input1, double input2, double output)
    {
        outputP = calculate(input1, input2);
        
        if (outputP > 0)
        {
            outputP = 1;
        }
        else
        {
            outputP = 0;
        }

        double error = output - outputP;
        weights[0] += error * input1 * lr;
        weights[1] += error * input2 * lr;
        weights[2] += error * bias * lr;

        // output weights
        
        // Console.WriteLine($"Weight[0] : {weights[0]}");
        // Console.WriteLine($"Weight[1] : {weights[1]}");
        // Console.WriteLine($"Weight[2] : {weights[2]}");
        // Console.WriteLine($"OutputP   : {outputP}");
        // Console.WriteLine($"Generation: {gen}");
        // Console.WriteLine($"error: {error}");
        // Thread.Sleep(50);
        // Console.Clear();
    }
    static void randomizeWeights()
    {
        for (int i = 0; i < 3; i++)
        {
            double temp = new Random().NextDouble();
            weights.Add(temp);
        }
    }

    static void learning ()
    {
        // Basic input for learning

        for (int i = 0; i < 50; i++)        
        {
            Perceptron(1, 1, 1);
            Perceptron(1, 0, 1);
            Perceptron(0, 1, 1);
            Perceptron(0, 0, 0);
            gen++;
        }
    }
    
    static void testing()
    {
        Console.Clear();
        Console.Write("0 or 1: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("0 or 1: ");
        double y = double.Parse(Console.ReadLine());

        double output = calculate(x, y);

        if (output > 0)
        {
            output = 1;
        }
        else
        {
            output = 0;
        }
        Console.WriteLine($"According to the NN your result is {output}");
    }

    static double calculate(double i1, double i2)
    {
        return i1 * weights[0] + i2 * weights[1] + bias * weights[2];
    }

    static void Main(string[] args)
    {
        randomizeWeights();
        learning();
        while (true)
        {
            testing();
        }

        Console.ReadKey();
    }
}
