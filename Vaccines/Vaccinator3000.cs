using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }

        public void Inject(Dog subject)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                subject.Alive = false;
                Console.WriteLine($"Dog {subject.ID} is dead by vaccination");
            }
            else
            {
                subject.Immunity = GetImmunity(3000);
            }
        }

        public void Inject(Cat subject)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                subject.Alive = false;
                Console.WriteLine($"Cat {subject.ID} is dead by vaccination");
            }
            else
            {
                subject.Immunity = GetImmunity(300);
            }
        }

        public void Inject(Pig subject)
        {
            if (randomElement.NextDouble() < 3 * DeathRate)
            {
                subject.Alive = false;
                Console.WriteLine($"Pig {subject.ID} is dead by vaccination");
            }
            else
            {
                subject.Immunity = GetImmunity(15);
            }
        }

        private string GetImmunity(int n)
        {
            int index;
            var size = Immunity.Length;
            var random = new Random();
            var sb = new StringBuilder(n);
            for (int i = 0; i < n; i++)
            {
                index = randomElement.Next(size);
                sb.Append(Immunity[index]);
            }
            return sb.ToString();
        }
    }
}
