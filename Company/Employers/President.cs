namespace Company.Employers;

public class President : Employer
{
    public President(
        string firstName, 
        string lastName, 
        Education education,
        int salary, 
        DateTime dob,
        int experience) : base(firstName, lastName, education, salary, dob, experience) { }
}