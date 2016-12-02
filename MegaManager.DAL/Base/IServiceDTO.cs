using System;
using System.Collections.Generic;


namespace MegaManager.Services
{
    public interface IServiceDTO<TDto>     
    {
        void Delete(int id);
        void Delete(TDto dto);
        IEnumerable<TDto> FindAll();        
        TDto FindById(int id);
        IEnumerable<TDto> FindMany(int start, int limit, out int total);
        bool Save(TDto dto, out string message);
    }
}
