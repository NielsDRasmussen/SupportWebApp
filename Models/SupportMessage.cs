using System.ComponentModel.DataAnnotations;

namespace SupportWebApp.Models;

public class SupportMessage
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Kategori er påkrævet")]
    public string Category { get; set; } = "";

    public Customer Customer { get; set; } = new();

    [Required(ErrorMessage = "Beskrivelse er påkrævet")]
    public string Description { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Open";
}

public class Customer
{
    [Required(ErrorMessage = "Navn er påkrævet")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email er påkrævet")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email")]
    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";
}