using API.Dtos.UserManager;
using API.Helpers.Base;
using static API.Configurations.DependencyInjectionConfig;

namespace API._Services.Interfaces;
[DependencyInjection(ServiceLifetime.Scoped)]
public interface I_Auth
{
    Task<OperationResult<AuthenticateResponse>> Login(LoginDto model);
}
