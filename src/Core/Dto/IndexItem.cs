namespace Core.Dto;

public class IndexItem
{
    public string Status { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public DateTime? RevocationDate { get; set; } = null;
    public string? RevocationReason { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string DistinguishedName { get; set; } = string.Empty;
}

public static class IndexItemExtensions 
{
    public  static IndexItem Map(this Domain.IndexItem source)
    {
        return new IndexItem()
        {
            Status = source.Status,
            ExpirationDate = source.ExpirationDate,
            RevocationDate = source.RevocationDate,
            RevocationReason = source.RevocationReason,
            SerialNumber = source.SerialNumber,
            DistinguishedName = source.DistinguishedName
        };
    }
}