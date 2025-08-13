using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace SmartLearningPlanner.MobileApp.Services;

public class JwtAuthHandler : DelegatingHandler
{
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var token = await SecureStorage.GetAsync("jwt_token");
		if (!string.IsNullOrEmpty(token))
		{
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
		}
		return await base.SendAsync(request, cancellationToken);
	}
}