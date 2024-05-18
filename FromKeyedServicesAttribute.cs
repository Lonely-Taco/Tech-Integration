namespace TechIntegration;

[AttributeUsage(AttributeTargets.Parameter)]
public class 
    FromKeyedServicesAttribute : Attribute, IControllerParameterDescriptor
{
    public string Key { get; }

    public FromKeyedServicesAttribute(string key)
    {
        Key = key;
    }
}

public interface IControllerParameterDescriptor
{
    string Key { get; }
}