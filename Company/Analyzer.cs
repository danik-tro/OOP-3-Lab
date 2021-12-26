namespace Company;

using Processors;

public class Analyzer<T>
    where T : DataProcessor, new()
{
    private T _dataProcessor = new T();

    public T Processor
    {
        set
        {
            if (value is not null)
                _dataProcessor = value;
            throw new Exception("Processor is invalid!");
        }
        
        get => _dataProcessor;
    }
    
    public Analyzer()
    {
    }
    
    public List<string> LoadData()
    {
        return _dataProcessor.LoadData();
    }
    
    public void UploadStatistics(List<string> statistics)
    {
        _dataProcessor.UploadData(statistics);
    }
    
    
    
    public void ShowStatistics(string fileName, bool outToFile = false)
    {
        var result = new List<string>();
        _dataProcessor.NameOfFile = fileName;

        var words = LoadData();
        var statistics = Analyze(words);
        
        result.Add(
                String.Format("{0,15} {1,15} {2,15}", "", "Слово:", "Кол-во:")
            );

        for (int item = 0; item < statistics.Count; item++)
        {
            var pair = statistics.ElementAt(item);
            result.Add(
                String.Format("{0,15} {1,15} {2,15}", item, pair.Key, pair.Value)
            );
        }
        
        result.Add($"Всего слов: {words.Count} из них уникальных {statistics.Count}");
        
        Console.WriteLine(string.Join(
            "\n",
            result
            ));
        
        if (outToFile)
        {
            UploadStatistics(result);
        }
    }

    public Dictionary<string, int> Analyze(List<string> words)
    {
        var statistics = new Dictionary<string, int>();

        foreach (var word in words)
        {
            statistics[word] = statistics.GetValueOrDefault(word, 0) + 1;
        }

        return statistics;
    }
}