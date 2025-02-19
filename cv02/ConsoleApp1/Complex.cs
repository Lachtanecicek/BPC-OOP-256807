using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Complex
{
    public double Realna;
    public double Imaginarni;

    public Complex(double realna = 0.0, double imaginarni = 0.0)
    {
        Realna = realna;
        Imaginarni = imaginarni;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Realna + b.Realna, a.Imaginarni + b.Imaginarni);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Realna - b.Realna, a.Imaginarni - b.Imaginarni);
    }

    public static Complex operator -(Complex a)
    {
        return new Complex(-a.Realna, -a.Imaginarni);
    }

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(a.Realna * b.Realna - a.Imaginarni * b.Imaginarni, a.Realna * b.Imaginarni + a.Imaginarni * b.Realna);
    }

    public static Complex operator /(Complex a, Complex b)
    {
        double jmenovatel = b.Realna * b.Realna + b.Imaginarni * b.Imaginarni;
        double vyslRealna = (a.Realna * b.Realna + a.Imaginarni * b.Imaginarni) / jmenovatel;
        double vyslImaginarni = (a.Imaginarni * b.Realna - a.Realna * b.Imaginarni) / jmenovatel;
        return new Complex(vyslRealna, vyslImaginarni);
    }

    public static bool operator ==(Complex a, Complex b)
    { 
        return a.Realna == b.Realna && a.Imaginarni == b.Imaginarni;
    }


    public static bool operator !=(Complex a, Complex b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        if (Imaginarni < 0)
        {
            return string.Format("{0} - {1}j", Realna, -Imaginarni);
        }
        else
        {
            return string.Format("{0} + {1}j", Realna, Imaginarni);
        }
    }

    public Complex Sdruzene()
    {
        return new Complex(Realna, -Imaginarni);
    }

    public double Modul()
    { 
        return Math.Sqrt(Realna * Realna + Imaginarni * Imaginarni);
    }

    public double Argument()
    { 
        return Math.Atan2(Imaginarni, Realna);
    }

}
