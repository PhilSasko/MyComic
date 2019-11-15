namespace MyComic.Domain.Retrievers
{
    public interface IRetriever<TTarger>
    {
        TTarger Retrieve();
    }

    public interface IFilePathRetriever : IRetriever<string>
    {
    }

    public class LocalFilePathRetriever : IFilePathRetriever
    {
        public string Retrieve()
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            return currentDirectory.Substring(0, currentDirectory.IndexOf("AppData"));
        }
    }
}