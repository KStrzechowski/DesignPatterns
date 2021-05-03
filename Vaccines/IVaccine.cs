using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    interface IVaccine
    {
        public string Immunity { get; }
        public double DeathRate { get; }

        void Inject(Dog subject);
        void Inject(Cat subject);
        void Inject(Pig subject);
    }
}
