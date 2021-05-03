using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }

        public void Inject(Dog subject)
        {
            subject.Immunity = Immunity;
        }

        public void Inject(Cat subject)
        {
            subject.Immunity = Immunity[3..];
            if (randomElement.NextDouble() < DeathRate)
            {
                subject.Alive = false;
                Console.WriteLine($"Cat {subject.ID} is dead by vaccination");
            }
        }

        public void Inject(Pig subject)
        {
            subject.Alive = false;
            Console.WriteLine($"Pig {subject.ID} is dead by vaccination");
        }
    }
}
