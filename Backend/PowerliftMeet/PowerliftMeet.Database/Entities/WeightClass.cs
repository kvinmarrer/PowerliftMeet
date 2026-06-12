namespace PowerliftMeet.Database.Entities;

public class WeightClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Weight { get; set; }
    
}