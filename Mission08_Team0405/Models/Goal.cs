namespace Mission08_Team0405.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Goal
{
    [Key]
    public int GoalId {get; set;}
    
    [Required]
    public string Task {get; set;}
    
    public string DueDate {get; set;}
    
    [Required]
    public int Quadrant {get; set;}
    
    [ForeignKey("CategoryId")]
    public int CategoryId {get; set;}
    public Category Category {get; set;}
    
    public bool Completed {get; set;}
    
}