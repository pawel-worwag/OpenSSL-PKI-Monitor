using System.Globalization;
using Core.Abstractions;
using Core.Domain;

namespace Core.Repositories;

public class IndexParser : IIndexParser
{
    public ICollection<CaIndexItem> ParseFile(string fileName)
    {
        var r = new List<CaIndexItem>();
        if (File.Exists(fileName))
        {
            var lines = File.ReadLines(fileName);
            foreach (var line in lines)
            {
                var attr = line.Split('\t');
                var item = new CaIndexItem();
                if (attr.Length >= 1) item.Status = attr[0].Trim();

                if (attr.Length >= 2)
                    try
                    {
                        item.ExpirationDate = DateTime.ParseExact("20" + attr[1].Trim(), "yyyyMMddHHmmssZ",
                            CultureInfo.InvariantCulture);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                if (attr.Length >= 3)
                    try
                    {
                        var parts = attr[2].Split(',');
                        if (parts.Length >= 1 && !string.IsNullOrEmpty(parts[0]))
                        {
                            item.RevocationDate = DateTime.ParseExact("20" + parts[0].Trim(), "yyyyMMddHHmmssZ",
                                CultureInfo.InvariantCulture);
                        }
                        if (parts.Length >= 2) item.RevocationReason = parts[1].Trim();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                if (attr.Length >= 4) item.SerialNumber = attr[3].Trim();
                if (attr.Length >= 5) item.FileName = attr[4].Trim();
                if (attr.Length >= 6) item.DistinguishedName = attr[5].Trim();

                r.Add(item);
            }
        }

        return r;
    }
}