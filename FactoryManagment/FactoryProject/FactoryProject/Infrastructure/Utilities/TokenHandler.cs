using System.Net.Http.Headers;

namespace FactoryProject.Infrastructure.Utilities;

public class TokenHandler :DelegatingHandler
{
    private readonly TokenContainer _tokenContainer;
    public TokenHandler(TokenContainer tokenContainer)
    {
        _tokenContainer = tokenContainer;
    }
    protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!String.IsNullOrEmpty(_tokenContainer.Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenContainer.Token);
       return await base.SendAsync(request, cancellationToken);
    }
}
