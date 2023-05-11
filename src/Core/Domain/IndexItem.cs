namespace Core.Domain;

public class IndexItem
{
    public string Status { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public DateTime? RevocationDate { get; set; } = null;
    public string? RevocationReason { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string DistinguishedName { get; set; } = string.Empty;
}
