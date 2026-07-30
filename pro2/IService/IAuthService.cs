using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro2.Dto;

namespace pro2.IService
{
    public interface IAuthService
    {
        Task<Tuple<int,string>>LoginUser(UserDto dto);
        
        
    }
}