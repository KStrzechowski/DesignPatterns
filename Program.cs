using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(IVirusDatabaseIterator it)
            {
                var virus = it.Next();
                while (virus != null)
                {
                    Console.WriteLine(virus.ToString());
                    virus = it.Next();
                }
                Console.WriteLine();
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"Testing {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        // process of vaccination
                        subject.GetVaccine(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function
                    var factoryIterator = new FactoryVirusDatabaseIterator();
                    var factoryCollection = new FactoryGenomeCollection();
                    var it = factoryIterator.GetIterator(simpleDatabase, factoryCollection.GetGenomeCollection(genomeDatabase));

                    var virus = it.Next();
                    while (virus != null)
                    {
                        foreach (var subject in subjects)
                        {
                            subject.GetTested(virus);
                        }
                        virus = it.Next();
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            var FactoryCollection = new FactoryGenomeCollection();
            var genomeCollection = FactoryCollection.GetGenomeCollection(genomeDatabase);
            var FactoryIterator = new FactoryVirusDatabaseIterator();
            IVirusDatabaseIterator it;

            Console.WriteLine("ETAP 1\n");

            Console.WriteLine("Simple database");
            it = FactoryIterator.GetIterator(simpleDatabase, genomeCollection);
            mediaOutlet.Publish(it);

            // TO DO EXCEL
            Console.WriteLine("Excell database");
            it = FactoryIterator.GetIterator(excellDatabase, genomeCollection);
            mediaOutlet.Publish(it);

            Console.WriteLine("Overcomplicated database");
            it = FactoryIterator.GetIterator(overcomplicatedDatabase, genomeCollection);
            mediaOutlet.Publish(it);

            Console.WriteLine("ETAP 2\n");

            Console.WriteLine("Filter:");
            it = FactoryIterator.GetIterator(excellDatabase, genomeCollection);
            mediaOutlet.Publish(new FilterIterator(it, new FilterDeathRateGreater(15)));

            Console.WriteLine("Mapping:");
            it = FactoryIterator.GetIterator(excellDatabase, genomeCollection);
            mediaOutlet.Publish(new FilterIterator(
                new ModifierIterator(
                    it, new ModifierDeathRate(10)), 
                new FilterDeathRateGreater(15)));

            Console.WriteLine("Concatenate:");
            it = FactoryIterator.GetIterator(excellDatabase, genomeCollection);
            var it2 = FactoryIterator.GetIterator(overcomplicatedDatabase, genomeCollection);
            mediaOutlet.Publish(new ConcatenateIterator(it, it2));

            Console.WriteLine("ETAP 3\n");

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
