using Core.Domain;

namespace Core.Abstractions;

public interface IIndexParser
{
    ICollection<CaIndexItem> ParseFile(string fileName);
}