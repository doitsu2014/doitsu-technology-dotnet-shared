namespace DoitsuTechnology.Shared.Application.Attributes;


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class CommandAuthorizeAttribute : Attribute
{
    public CommandAuthorizeAttribute()
    {
        
    }
    
    public string Roles { get; set; } = string.Empty;
    public string Policy { get; set; } = string.Empty;
}