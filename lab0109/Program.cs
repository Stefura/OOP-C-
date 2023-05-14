using System;

public delegate double FunctionDelegate(double x);
public delegate double DerivativeDelegate(double x);

class NewtonRaphsonSolver
{
    public static double SolveEquation(FunctionDelegate function, DerivativeDelegate derivative, double initialGuess)
    {
        double x = initialGuess;
        const double tolerance = 0.0001;
        int maxIterations = 100;
        int iteration = 0;
        while (iteration < maxIterations)
        {
            double fx = function(x);
            double dx = derivative(x);

            if (Math.Abs(dx) < tolerance)
            {
                break;
            }

            x = x - fx / dx;
            iteration++;
        }

        return x;
    }

    public static void Main()
    {
       
        FunctionDelegate function = x => x * x - 4; 
        DerivativeDelegate derivative = x => 2 * x; 
        double initialGuess = 2; 
        double root = SolveEquation(function, derivative, initialGuess);

        Console.WriteLine("Root: " + root);
    }
}