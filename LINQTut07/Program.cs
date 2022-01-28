using LINQTut07.Shared;
using System;
using System.Linq;

namespace LINQTut07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAny();
            RunAll();
            RunAnyAllQuerySyntax();
            RunContain();
            Console.ReadKey();
        }
        private static void RunAny()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++");
            Console.WriteLine("Run Any()");
            Console.WriteLine("+++++++++");
            Console.WriteLine();


            var employees = Repository.LoadEmployees();


            // if any employee name starts with some sequence of letter
            var input1 = "jac";
            var result1 = employees.Any(e => e.Name.StartsWith(input1, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"find employee with name starts with '{input1}' result: {result1}");

            // if any employee employee salary less tham 1000
            var input2 = 10000;
            var result2 = employees.Any(e => e.Salary < input2);
            Console.WriteLine($"at least one employee with salary less than {input2.ToString("C2")} result: {result2}");

            // if any employee with skills less tham 1000
            var noOfSkills = 1;
            var result3 = employees.Any(e => e.Skills.Count < noOfSkills);
            Console.WriteLine($"at least one employee with skill count less than {noOfSkills} result: {result3}");
             
        }

        private static void RunAll()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++");
            Console.WriteLine("Run All()");
            Console.WriteLine("+++++++++"); 
            Console.WriteLine();

            var employees = Repository.LoadEmployees();

            // if all employees have email defined
            var result1 = employees.All(e => !string.IsNullOrWhiteSpace(e.Email));
            Console.WriteLine($"All employees have email result: {result1}");

            // if all employees have at least 1 skill
            var result2 = employees.All(e => e.Skills.Any(x => x.Contains("C#")));
            Console.WriteLine($"All employees have c# in their skills list result: {result2}");
        }

        private static void RunAnyAllQuerySyntax()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Run All() + Any() Query Expression");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            var employees = Repository.LoadEmployees();

            var result1 = from emp in employees
                          where emp.Skills.All(x => x.Contains("c", StringComparison.OrdinalIgnoreCase))
                          select emp;

            result1.Print("Employees having skills  > skills");

            var result2 = from emp in employees
                          where emp.Skills.Any(x => x.Contains("node", StringComparison.OrdinalIgnoreCase))
                          select emp;

            result2.Print("Employees having skill node");
        }

        private static void RunContain()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++");
            Console.WriteLine("Run Contain()");
            Console.WriteLine("++++++++++++++");
            Console.WriteLine();
            var employees = Repository.LoadEmployees();


            // if any employee contains 'ee' in his/her name

            var e1 = employees.ToArray()[0];
            var result1 = employees.Contains(e1);
            Console.WriteLine($"find if any employee contains " +
                $"'{e1.Email}' in his/her name result: {result1}");

            var e2 = new Employee { Email = "Cole.Cochran02@example.com" };
            var result2 = employees.Contains(e2);
            Console.WriteLine($"find if any employee contains " +
                $"'{e2.Email}' in his/her name result: {result2}");
        }
    }
}
