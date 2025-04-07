using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv09
{
    public class Calculator
    {
        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };

        private Stav _stav = Stav.PrvniCislo;

        private string _prvni = "";
        private string _druhe = "";
        private string _operace = "";
        private string _display = "0";
        private string _pamet = "";
        private double _pametHodnota = 0;

        public string Display => _display;
        public string Pamet => _pamet;

        public void Tlacitko(string tl)
        {
            if (double.TryParse(tl, out _) || tl == ",")
            {
                ZpracujCislo(tl);
            }
            else
            {
                ZpracujOperaci(tl);
            }
        }

        private void ZpracujCislo(string cislo)
        {
            switch (_stav)
            {
                case Stav.PrvniCislo:
                case Stav.Vysledek:
                    if (_stav == Stav.Vysledek)
                    {
                        _prvni = "";
                        _operace = "";
                        _stav = Stav.PrvniCislo;
                    }
                    if (cislo == "," && _prvni.Contains(",")) return;
                    _prvni += cislo;
                    _display = _prvni;
                    break;

                case Stav.Operace:
                    _druhe = "";
                    _stav = Stav.DruheCislo;
                    goto case Stav.DruheCislo;

                case Stav.DruheCislo:
                    if (cislo == "," && _druhe.Contains(",")) return;
                    _druhe += cislo;
                    _display = _druhe;
                    break;
            }
        }

        private void ZpracujOperaci(string op)
        {
            switch (op)
            {
                case "C":
                    _prvni = _druhe = _operace = "";
                    _display = "0";
                    _stav = Stav.PrvniCislo;
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    if (!string.IsNullOrEmpty(_prvni))
                    {
                        _operace = op;
                        _stav = Stav.Operace;
                    }
                    break;

                case "=":
                    Spocitej();
                    break;

                case "M+":
                    double.TryParse(_display, out _pametHodnota);
                    _pamet = "M";
                    break;

                case "MR":
                    _display = _pametHodnota.ToString(CultureInfo.InvariantCulture);
                    if (_stav == Stav.PrvniCislo || _stav == Stav.Vysledek)
                    {
                        _prvni = _display;
                    }
                    else if (_stav == Stav.DruheCislo)
                    {
                        _druhe = _display;
                    }
                    break;

                case "MC":
                    _pamet = "";
                    _pametHodnota = 0;
                    break;

                case "+/-":
                    if (_stav == Stav.PrvniCislo || _stav == Stav.Vysledek)
                    {
                        if (_prvni.StartsWith("-"))
                            _prvni = _prvni.Substring(1);
                        else
                            _prvni = "-" + _prvni;
                        _display = _prvni;
                    }
                    else if (_stav == Stav.DruheCislo)
                    {
                        if (_druhe.StartsWith("-"))
                            _druhe = _druhe.Substring(1);
                        else
                            _druhe = "-" + _druhe;
                        _display = _druhe;
                    }
                    break;
            }
        }

        private void Spocitej()
        {
            if (double.TryParse(_prvni, out double a) && double.TryParse(_druhe, out double b))
            {
                double vysledek = 0;
                switch (_operace)
                {
                    case "+": vysledek = a + b; break;
                    case "-": vysledek = a - b; break;
                    case "*": vysledek = a * b; break;
                    case "/":
                        if (b != 0)
                            vysledek = a / b;
                        else
                        {
                            _display = "CHYBA";
                            return;
                        }
                        break;
                }
                _display = vysledek.ToString(CultureInfo.InvariantCulture);
                _prvni = _display;
                _stav = Stav.Vysledek;
            }
        }
    }
}
