TestComplex.Test(new Complex(3.0, 5.0), new Complex(2.0, 1.0) + new Complex(1.0, 4.0), "operator +");
TestComplex.Test(new Complex(1.0, -3.0), new Complex(2.0, 1.0) - new Complex(1.0, 4.0), "operator -");

TestComplex.Test(new Complex(-2.0, -1.0), - new Complex(2.0, 1.0), "operator unarni -");

Console.WriteLine("Operator ==: {0}", new Complex(2.0, 1.0) == new Complex(2.0, 1.0));

Console.WriteLine("Modul: {0}", new Complex(2.0, 2.0).Modul());
Console.WriteLine("Modul: {0}", new Complex(2.0, 2.0).Argument());