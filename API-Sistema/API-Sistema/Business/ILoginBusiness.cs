using API_Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVo user);
    }
}
