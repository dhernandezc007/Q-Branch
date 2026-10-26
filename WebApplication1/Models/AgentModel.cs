using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class AgentModel
{
    public string Id { get; set; } = "";
    
    [Required] // Regular expression (Regex) : Makes this input required    
    public string Name  { get; set; } = "";

    [Required] // Regular expression (Regex) : Makes this input required 
    public string Nationality  { get; set; } = "";
    
    [Required] // Regular expression (Regex) : Makes this input required 
    public string Organization   { get; set; } = "";
    
}