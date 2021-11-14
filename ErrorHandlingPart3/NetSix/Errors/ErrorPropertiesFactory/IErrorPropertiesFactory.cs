namespace NetSix.Errors.ErrorPropertiesFactory;

public interface IErrorPropertiesFactory
{
    IDictionary<string, object?> CreateCommonProperties();
}