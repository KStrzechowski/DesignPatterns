using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public int modifier = 0;
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "ReverseVaccine";
        }

        public void Inject(Dog subject)
        {
            modifier++;
            char[] nucleotides = Immunity.ToCharArray();
            Array.Reverse(nucleotides);
            subject.Immunity = nucleotides.ToString();
        }

        public void Inject(Cat subject)
        {
            modifier++;
            subject.Alive = false;
            Console.WriteLine($"Cat {subject.ID} is dead by vaccination");
        }

        public void Inject(Pig subject)
        {
            char[] nucleotides = Immunity.ToCharArray();
            Array.Reverse(nucleotides);
            subject.Immunity = Immunity + nucleotides.ToString();
            if (randomElement.NextDouble() < DeathRate * modifier)
            {
                subject.Alive = false;
                Console.WriteLine($"Pig {subject.ID} is dead by vaccination");
            }
            modifier++;
        }
    }
}
