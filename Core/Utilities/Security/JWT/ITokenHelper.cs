using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Kullanıcının girdiği bilgiler Apiye gönderildi.
        //Eğer doğruysa burda CreateToken operasyonu çalışacak. eğer doğruysa ilgili kullanıcı için veritabanına gidecek. veri tabanında bu kullanıcının claimlerini bulacak. 
        //orda bir tane JWT üretecek ve onları geri verecek.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
