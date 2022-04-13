namespace RoadSystemControl.Domains.Models;


public class Police : BaseModel
{
    public int LocationId { get; set; }
    public string FirstPhone { get; set; }
    public string SecondPhone { get; set; }
    public Location Location { get; set; }
}