namespace Company.Employers;

public class Worker : Employer
{
    public Worker(
        string firstName, 
        string lastName, 
        Education education,
        int salary,
        DateTime dob,
        int experience) : base(firstName, lastName, education, salary, dob, experience) { }
}