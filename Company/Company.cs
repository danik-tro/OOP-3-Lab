using Company.Employers;

namespace Company;

public class Company<T>
    where T: Employer
{
    private T? president = null;
    private List<T> employers = new List<T>();
    
    public string Name { get; set; }
    public T? President
    {
        set
        {
            if (value is not null)
                president = value;
            else
                throw new Exception("President must be initialized!");
        }
        get => president;
    }

    public Company(string name)
    {
        Name = name;
    }
    
    public int NumberOfEmployees()
    {
        return employers.Count();
    }

    public List<T> ShowInfoAboutEmployersByMonth(int month)
    {
        return employers.Where(u => u.DoB.Month == month).ToList();
    }

    public List<T> ShowInfoByName(string name)
    {
        return employers.Where(u => u.FirstName == name).ToList();
    }
    
    public List<Manager> YoungerAndOlderManagers()
    {
        var managers = employers.OfType<Manager>().OrderBy(u => u.DoB).ToList();
        return new List<Manager>
        {
            managers.First(),
            managers.Last()
        };
    }
    
    public T TenExperiencedYoungerAndWithHigherEducation()
    {
        var items = (
            from user in employers
            orderby user.Experience descending 
            select user
        ).Take(10).ToList();

        return (
            from item in items
            orderby item.DoB descending 
            where item.HigherEducation is Education.Higher
            select item
        ).First();
    }
    
    public int AggBySalary()
    {
        return employers.Sum(u => u.Salary);
    }
    
    public void RegisterEmployers(ref List<T> employers)
    {
        this.employers.AddRange(employers);
    }

    public void RegisterPresident(T employee)
    {
        President = employee;
        RegisterEmployer(employee);
    }
    
    public void RegisterEmployer(T employee)
    {
        employers.Add(employee);
    }
}