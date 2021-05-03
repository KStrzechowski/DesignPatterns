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

                    // process of vaccination
                    foreach (var subject in subjects)
                    {
                        subject.GetVaccine(vaccine);
                    }

                    // testing immunity
                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    var Factory = new FactoryDatabase();
                    var it = Factory.GetIterator(simpleDatabase, Factory.GetGenomeCollection(genomeDatabase));

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

            var Factory = new FactoryDatabase();
            var genomeCollection = Factory.GetGenomeCollection(genomeDatabase);

            Console.WriteLine("ETAP 1\n");

            Console.WriteLine("Simple database");
            var it = Factory.GetIterator(simpleDatabase, genomeCollection);
            mediaOutlet.Publish(it);

            Console.WriteLine("Excell database");
            it = Factory.GetIterator(excellDatabase, genomeCollection);
            mediaOutlet.Publish(it);

            Console.WriteLine("Overcomplicated database");
            it = Factory.GetIterator(overcomplicatedDatabase, genomeCollection);
            mediaOutlet.Publish(it);

            Console.WriteLine("ETAP 2\n");

            Console.WriteLine("Filter:");
            it = Factory.GetIterator(excellDatabase, genomeCollection);
            mediaOutlet.Publish(new FilterIterator(it, new FilterDeathRateGreater(15)));

            Console.WriteLine("Mapping:");
            it = Factory.GetIterator(excellDatabase, genomeCollection);
            mediaOutlet.Publish(new FilterIterator(
                new ModifierIterator(
                    it, new ModifierDeathRate(10)), 
                new FilterDeathRateGreater(15)));

            Console.WriteLine("Concatenate:");
            it = Factory.GetIterator(excellDatabase, genomeCollection);
            var it2 = Factory.GetIterator(overcomplicatedDatabase, genomeCollection);
            mediaOutlet.Publish(new ConcatenateIterator(it, it2));

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
