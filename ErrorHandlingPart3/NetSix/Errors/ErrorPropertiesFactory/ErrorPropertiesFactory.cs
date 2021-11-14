using Microsoft.AspNetCore.Http.Features;

namespace NetSix.Errors.ErrorPropertiesFactory;

public class ErrorPropertiesFactory : IErrorPropertiesFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ErrorPropertiesFactory(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IDictionary<string, object?> CreateCommonProperties()
    {
        var originalRequestPath = _httpContextAccessor.HttpContext?
            .Features.Get<IHttpRequestFeature>()?
            .RawTarget;

        return new Dictionary<string, object?>
        {
            { "myCustomProperty", "myCustomPropertyValue"},
            { "somePropertyBasedOnHttpContext", originalRequestPath }
        };
    }
}