using Core.Domain;

namespace Core.Abstractions;

public interface IIndexParser
{
    ICollection<IndexItem> ParseFile(string FileName);
}