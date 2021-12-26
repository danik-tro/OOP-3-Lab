using Company.Employers;
using Company.Processors;

namespace Company
{
    public class Program
    {
        private static Random random = new Random();
        public static string RandomName(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomSalary()
        {
            return random.Next(10000, 900000);
        }
        
        public static DateTime RandomDate()
        {
            return new DateTime(
                random.Next(1950, 2005),
                random.Next(1, 12),
                random.Next(1, 28)
            );
        }

        public static Manager RandomManager()
        {
            return new Manager(
                RandomName(),
                RandomName(),
                RandomEducation(),
                RandomSalary(),
                RandomDate(),
                random.Next(0, 35)
            );
        }
        
        public static Worker RandomWorker()
        {
            return new Worker(
                RandomName(),
                RandomName(),
                RandomEducation(),
                RandomSalary(),
                RandomDate(),
                random.Next(0, 35)
            );
        }
        
        public static Education RandomEducation()
        {
            Array values = Enum.GetValues(typeof(Education));
            
            return (Education)values.GetValue(random.Next(values.Length));
        }

        public static void TestCompany()
        {
            var president = new President(
                "Daniel",
                "Trotsenko",
                Education.Higher,
                1000000,
                new DateTime(2001, 8, 7), 
                10
            );
            
            var vladimir_worker = new Worker(
                "Vladimir",
                "Doroshenko",
                Education.Higher,
                1000000,
                new DateTime(1999, 8, 7), 
                5
            );
            
            var company = new Company<Employer>("Google");
            company.RegisterPresident(president);
            company.RegisterEmployer(vladimir_worker);
            // Register managers and workers
            for (int i = 0; i < 50; i++)
            {
                company.RegisterEmployer(
                    RandomManager()
                );
                company.RegisterEmployer(
                    RandomWorker()
                );
            }
            
            Console.WriteLine(company.NumberOfEmployees());
            Console.WriteLine(company.AggBySalary());
            Console.WriteLine(company.TenExperiencedYoungerAndWithHigherEducation());
            var vladimir = company.ShowInfoByName("Vladimir").OrderBy(u => u.DoB).Last();
            vladimir.Salary += (int)(vladimir.Salary * 0.3);
            Console.WriteLine(vladimir);

            var octobers_employee = company.ShowInfoAboutEmployersByMonth(10);
            foreach (var u in octobers_employee)
            {
                Console.WriteLine(u);
            }
        }

        public static void TestAnalyzer()
        {
            var analyzer = new Analyzer<DataProcessor>();
            analyzer.ShowStatistics("FirstFile.txt", true);

        }
        
        private static void Main(string[] args)
        {
            TestAnalyzer();
            // TestCompany();
        }
    }
}

