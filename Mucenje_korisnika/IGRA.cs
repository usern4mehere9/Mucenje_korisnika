using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mucenje_korisnika
{
    abstract public class Igra
    {
        abstract public void Pocni(int n);
        abstract public string Odgovor(int Pokusaj);
    }

    internal class Laksi : Igra
    {
        private int Zamisljeni, maksimalan;

        public override string Odgovor(int Pokusaj)
        {
            if (Pokusaj > maksimalan)
            {
                return "Van opsega";
            }

            if (Pokusaj > Zamisljeni)
            {
                return "Manji";
            }
            else if (Pokusaj < Zamisljeni)
            {
                return "Veci";
            }
            else if (Pokusaj == Zamisljeni)
            {
                return "Pogodjen";
            }

            return string.Empty;
        }

        public override void Pocni(int n)
        {
            Random razmisljam = new Random();
            Zamisljeni = (1 + razmisljam.Next()) % n;
            maksimalan = n;
        }
    }

    internal class Tezi : Igra
    {
        private int opseg, max, min;

        public static bool Kraj(int max, int min)
        {
            if (Math.Abs(max - min) == 1)
            {
                return true;
            }
            return false;
        }

        public override string Odgovor(int Pokusaj)
        {
            int delta_min, delta_max;
            delta_min = Math.Abs(min - Pokusaj);
            delta_max = Math.Abs(max - Pokusaj);

            if (Pokusaj > opseg)
            {
                return "Van opsega";
            }


            if (delta_min == delta_max)
            {
                min = Pokusaj;

                if (!Kraj(max, min))
                {
                    return "Veci";
                }
                return "Pogodjen";
            }
            else if (delta_min > delta_max)
            {
                max = Pokusaj;
                if (!Kraj(max, min))
                {
                    return "Manji";
                }
                return "Pogodjen";
            }
            else if (delta_min < delta_max)
            {
                min = Pokusaj;
                if (!Kraj(max, min))
                {
                    return "Veci";
                }
                return "Pogodjen";
            }

            return string.Empty;
        }

        public override void Pocni(int n)
        {
            opseg = n;
            max = n;
            min = 1;
        }
    }

}
