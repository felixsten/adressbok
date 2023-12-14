using System.Diagnostics;

namespace adressbokMaui.Services;

public interface IFileService
{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}
public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;
    /// <summary>
    /// sparar information till fil med streamwriter
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool SaveContentToFile(string content)
    {

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

    /// <summary>
    /// läser igenom fil med streamreader
    /// </summary>
    /// <returns></returns>
    public string GetContentFromFile()
    {

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

