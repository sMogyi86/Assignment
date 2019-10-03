using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SomogyiMate_A2G3SP_Game
{
    public delegate void NewPrimeAddedEventHandler(ulong n);

    class Prime
    {
        // megtalált prímszámok, növekvő sorrendben
        private readonly List<ulong> primes;
        public ulong[] Primes
        {
            get
            {
                ulong[] ret = new ulong[this.primes.Count];
                this.primes.CopyTo(ret);
                return ret;
            }
        }

        public event NewPrimeAddedEventHandler newPrimeAdded;

        public Prime()
        {
            this.primes = new List<ulong>();
            this.primes.Add(2);
        }

        public bool IsItPrime(ulong n)
        {
            if (n == 0 || n == 1) { return false; }
            else
            {
                if (n <= this.primes.Last() && this.primes.BinarySearch(n) != -1)
                {
                    return true;
                }
                else
                {
                    return IsItPrimeAndExpand(n);
                }
            }
        }

        private bool IsItPrimeAndExpand(ulong n)
        {
            int i = 0;
            //végig nézzük a listában szereplő prímekkel az osztási maradékot,            
            while (i < this.primes.Count && n % this.primes.ElementAt(i) != 0 && this.primes.ElementAt(i) < (ulong)Math.Sqrt(n) + 1)
            {
                i++;
            }
            if (i < this.primes.Count)
            {
                // Ha azért ugrottunk ki, mert találtunk osztóját, akkor nem prím
                if (n % this.primes.ElementAt(i) == 0) { return false; }
                // Ha azért zgrottunk ki, mert már túlmentünk a gyökén(és az előző IFben nem ugrottunk ki, mert itt járunk=> nem volt osztója), akkor  akokr ez egy prím szám
                if (this.primes.ElementAt(i) > (ulong)Math.Sqrt(n) + 1) { return true; }
            }
            //egyébként csak elfogytak az osztók és attól még lehet prím is meg nem is
            // folytatjuk prímek listájának bővítését és minden új taggal vizsáljuk a számot            
            while (n % this.primes.Last() != 0 && this.primes.Last() < (ulong)Math.Sqrt(n) + 1)
            {
                this.primes.Add(GetNextPrime(this.primes.Last()));
                if (this.newPrimeAdded != null) { this.newPrimeAdded(this.primes.Last()); }
            }
            // ha találtunk osztót akkor nem príim
            // egyébként pedig nem volt a gyökéig osztó, tehát prím
            if (n % this.primes.Last() == 0) { return false; } else { return true; }
        }

        private ulong GetNextPrime(ulong from)
        {
            // Mindig akadnak elvetemültek...
            if (from == 0 || from == 1) { return this.primes.First(); }
            else
            {
                ulong n;
                // A keresés során a páratlan számokon lépdelünk kettesével
                // Ha egy páros számot kaptunk előbb növelni kell egyel
                if ((from % 2) == 0) { n = from + 1; } else { n = from + 2; }

                bool isPrime = false;
                // szám növelése kettesével, amíg nem lesz prím
                while (!isPrime)
                {
                    int i = 0;
                    // az új jelöltet elosztjuk, az őt megelőző prímekkel
                    while (((n % this.primes.ElementAt(i)) != 0) && this.primes.ElementAt(i) < (ulong)Math.Sqrt(n) + 1)
                    {
                        i++;
                    }
                    // Ha nem azért ugrottunk ki mert a maradék=0 akkor ez egy prímszám                    
                    if ((n % this.primes.ElementAt(i)) != 0)
                    {
                        isPrime = true;
                    }
                    // Egyébként jöhet a következő vizsgálandó szám
                    else
                    {
                        try
                        {
                            n = n + 2;
                        }
                        catch (OverflowException e)
                        {

                            throw new OverflowException("GetNextPrime: ulong is ulong Man... This is The End! ;)", e);
                        }
                    }
                }
                return n;
            }
        }

        public void ClearPrimesList()
        {
            this.primes.Clear();
        }

        public ulong[][] GetPrimeComposite(ulong n)
        {
            if (n == 0 || n == 1) { throw new DivideByZeroException(n.ToString() + " is not splitable!"); }
            if (IsItPrime(n)) { return new ulong[1][] { new ulong[] { 1, n } }; }
            else
            {
                ulong divident = n; // osztandó                
                ulong divisor; // osztó                        
                List<ulong[]> subRet = new List<ulong[]>(); // Eredmény lista

                int i = 0;
                do
                {
                    // osztó prím szám értékadás
                    // ha még van a listában onnan
                    if (i < this.primes.Count)
                    {
                        divisor = this.primes.ElementAt(i);
                        i++;
                    }
                    // Ha nem előállítjuk a következőt
                    else
                    {
                        this.primes.Add(GetNextPrime(this.primes.Last()));
                        divisor = this.primes.Last();
                    }
                    // És ezzel most addig osztogatunk amígcsak lehet, számolva közben a kitevőt
                    uint exp = 0;
                    while (divident % divisor == 0)
                    {
                        exp++;
                        divident = divident / divisor;
                    }
                    // Ha volt sikeres osztás, akkor a tényezőt és kitevőjét hozzáadjuk az eredmény tömbhöz
                    if (exp > 0)
                    {
                        subRet.Add(new ulong[] { divisor, exp });
                    }
                } while (divident != 1);

                ulong[][] ret = new ulong[subRet.Count][];

                subRet.CopyTo(ret);

                return ret;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ulong item in this.primes)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}