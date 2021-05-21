using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public static IVirusInfoDatabaseIterator GetDatabaseIterator(SimpleDatabase database)
            => new SimpleDatabaseIterator(database);
        public static IVirusInfoDatabaseIterator GetDatabaseIterator(ExcellDatabase database)
            => new ExcellDatabaseIterator(database);
        public static IVirusInfoDatabaseIterator GetDatabaseIterator(OvercomplicatedDatabase database)
            => new OvercomplicatedDatabaseIterator(database);

        public static IVirusDatabaseIterator GetVirusIterator(IVirusInfoDatabaseIterator it, SimpleGenomeDatabase genomeCollection)
            => new VirusWithGenomeIterator(it, new SimpleGenomeCollection(genomeCollection));
        public static IVirusDatabaseIterator GetVirusIterator(IVirusInfoDatabaseIterator it)
            => new VirusWithGenomeIterator(it);

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
                    var it = GetVirusIterator(GetDatabaseIterator(simpleDatabase), genomeDatabase);

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

            Console.WriteLine("ETAP 1\n");

            Console.WriteLine("Simple database without genomes");
            var it = GetVirusIterator(GetDatabaseIterator(simpleDatabase));
            mediaOutlet.Publish(it);

            Console.WriteLine("Simple database with genomes");
            it = GetVirusIterator(GetDatabaseIterator(simpleDatabase), genomeDatabase);
            mediaOutlet.Publish(it);

            Console.WriteLine("Excell database");
            it = GetVirusIterator(GetDatabaseIterator(excellDatabase), genomeDatabase);
            mediaOutlet.Publish(it);

            Console.WriteLine("Overcomplicated database");
            it = GetVirusIterator(GetDatabaseIterator(overcomplicatedDatabase), genomeDatabase);
            mediaOutlet.Publish(it);

            Console.WriteLine("ETAP 2\n");

            Console.WriteLine("Filter:");
            it = GetVirusIterator(GetDatabaseIterator(excellDatabase), genomeDatabase);
            mediaOutlet.Publish(new FilterIterator(it, new FilterDeathRateGreater(15)));

            Console.WriteLine("Mapping:");
            it = GetVirusIterator(GetDatabaseIterator(excellDatabase), genomeDatabase);
            mediaOutlet.Publish(new FilterIterator(
                new ModifierIterator(
                    it, new ModifierDeathRate(10)), 
                new FilterDeathRateGreater(15)));

            Console.WriteLine("Concatenate:");
            it = GetVirusIterator(GetDatabaseIterator(excellDatabase), genomeDatabase);
            var it2 = GetVirusIterator(GetDatabaseIterator(overcomplicatedDatabase), genomeDatabase);
            mediaOutlet.Publish(new ConcatenateIterator(it, it2));

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
