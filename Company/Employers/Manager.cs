namespace Company.Employers;

public class Manager : Employer
{
    public Manager(
        string firstName, 
        string lastName, 
        Education education,
        int salary, 
        DateTime dob, 
        int experience) : base(firstName, lastName, education, salary, dob, experience) { }
}