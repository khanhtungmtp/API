using API._Repositories;

namespace API._Services.Services;

public class S_BaseServices(IRepositoryAccessor repositoryAccessor)
{
    protected readonly IRepositoryAccessor _repositoryAccessor = repositoryAccessor;
}
