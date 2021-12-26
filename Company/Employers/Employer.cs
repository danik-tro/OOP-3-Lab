namespace Company.Employers;

public abstract class Employer
{
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public Education HigherEducation { set; get; }
    public int Salary { set; get; }
    public int Experience { set; get; }
    public DateTime DoB { get; init; }

    public Employer(string firstName, string lastName, Education education, int salary, DateTime dob, int experience)
    {
        FirstName = firstName;
        LastName = lastName;
        HigherEducation = education;
        Salary = salary;
        DoB = dob;
        Experience = experience;
    }

    public override string ToString()
    {
        return $"Employee info: {FirstName} {LastName}. Salary: {Salary}. " +
               $"DoB: {DoB} with experience: {Experience}. " +
               $"Education: {HigherEducation}";
    }
}