using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.Services
{
    //Controller'ı kullandığımız servislerden bağımsız hale getirmek için bir örnek
    //Bu servisler log yapısı olabilir entity framework olabilir vs.vs.
    //Startup.cs dosyasında ICalculator new lendiğinde hangisinin kullanıcağını belirtiyoruz [Madde24]
    public interface ICalculator
    {
        double Calculate(double amount);
    }
}
