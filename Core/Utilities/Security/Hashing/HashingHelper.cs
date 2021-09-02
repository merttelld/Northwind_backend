using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Bu kısım verdiğimiz şifrenin hashini oluşturmaya yarıyor
        public static void CreatePasswordHash
            (string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //Bu kısım ise sonradan sisteme girmeye çalışan birinin verdiği şifrenin bizim verikaynağımızdaki 
        //hashla ilgili Salt'a göre eşleşip eşleşmediğini verdiğimiz yer 
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    //Eğer computedHashin(hesaplanan hashin) i.değeri veritabanından 
                    //gönderilen hashin i.değerine eşit değilse false döndür
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
