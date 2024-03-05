namespace Mucenje_korisnika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool tezina;
            int max, uneti;
            string odgovor;

            Igra igra;

            Console.Write("Unesite max opsega: ");
            max = int.Parse(Console.ReadLine());

            Console.Write("Izabrite tezinu igre[true - laka | false - teska]: ");
            tezina = bool.Parse(Console.ReadLine());

            if (tezina)
            {
                igra = new Laksi();
                igra.Pocni(max);
            }
            else
            {
                igra = new Tezi();
                igra.Pocni(max);
            }

            do
            {
                Console.Write("Unesite broj: ");
                uneti = int.Parse(Console.ReadLine());
                odgovor = igra.Odgovor(uneti);
                Console.WriteLine("Zamisljeni broj je: {0}", odgovor);
            } while (odgovor != "Pogodjen");
        }
    }
}