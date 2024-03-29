namespace API.Dtos.Base;

public class FilterSearch
{
    public bool? Contains { get; set; }
    public bool? IsEquaTo { get; set; }
    public bool? GreaterThan { get; set; }
    public bool? LessThan { get; set; }
}
