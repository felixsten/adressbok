

using System.Diagnostics;

namespace adressbok.Services;

public interface IFileService
{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}
public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public bool SaveContentToFile(string content)
    {
        // använder streamwriter för att spara information till json fil
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    public string GetContentFromFile()
    {
        // använder streamreader för att läsa genom hela json filen 
        try
        {
            if (File.Exists(_filePath))
            {
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


}
