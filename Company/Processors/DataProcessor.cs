using System.Text.RegularExpressions;

namespace Company.Processors;

public class DataProcessor
{
    public string PathToFile { get; init; }
    public string NameOfFile { get; set; }

    public DataProcessor()
    {
        var startupPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        PathToFile = startupPath.Parent.Parent.Parent.FullName;
    }
    
    public DataProcessor(string pathToFile) : this()
    {
        NameOfFile = pathToFile;
    }

    public List<string> LoadData()
    {
        var result = new List<string>();
        
        using (StreamReader sr = File.OpenText(Path.Combine(PathToFile, NameOfFile)))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                result.AddRange(GetWords(s));
            }
        }

        return result;
    }
    
    public void UploadData(List<string> analyzerList)
    {
        using (StreamWriter sw = File.CreateText(Path.Combine(PathToFile, $"analyze-{NameOfFile}")))
        {
            foreach (var line in analyzerList)
            {
                sw.WriteLine(line);
            }
        }
    }
    
    public static List<string> GetWords(string input)
    {
        MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");
    
        var words = from m in matches.Cast<Match>()
            where !string.IsNullOrEmpty(m.Value)
            select TrimSuffix(m.Value);
    
        return words.ToList();
    }
    
    public static string TrimSuffix(string word)
    {
        int apostropheLocation = word.IndexOf('\'');
        if (apostropheLocation != -1)
        {
            word = word.Substring(0, apostropheLocation);
        }
    
        return word;
    }
}