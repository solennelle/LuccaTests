using LuccaDevises.Models;

namespace LuccaDevises
{
    public interface IFileParser {
        InputFile ParseEntryFile(string filePath);
    }
}