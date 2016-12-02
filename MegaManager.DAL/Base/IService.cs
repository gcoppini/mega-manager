using System;
using System.Collections.Generic;


namespace MegaManager.Services
{
    public interface IService<TEntity, TDto> : IServiceDTO<TDto>, IBaseService
    {
        
    }
}
