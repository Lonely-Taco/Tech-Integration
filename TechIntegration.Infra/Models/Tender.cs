namespace TechIntegration.Core.Models;

public class Tender
{
    public Guid Id { get; set; }
    public Guid TenderId { get; set; }
    public string? LotNumber { get; set; }
    public DateTime? Deadline { get; set; }
    public string? Name { get; set; }
    public string? TenderName { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool HasDocuments { get; set; }
    public string? Location { get; set; }
    public string? PublicationDate { get; set; }
    public int Status { get; set; }
    public string? Currency { get; set; }
    public string? Value { get; set; }
}