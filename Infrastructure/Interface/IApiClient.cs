using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
  public  interface IApiClient
    {
         List<ApiRess> GetAsync2(string building , string token);
        List<ApiRess> GetAsyn3(BodyInfo body, string token);
        ApiRess AddAsync(ApiRess body);
        ApiRess DeleteAsync(int personId);
        ApiRess UpdatePerson(ApiRess body);
    }
}
