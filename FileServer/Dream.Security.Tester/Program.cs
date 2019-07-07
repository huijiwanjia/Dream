using System;

namespace Dream.Security.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Provider.Encrypt("e5a193b1-0560-11e8-b1b7-7cd30ab8a58e");
            var ss = Provider.KeyIsAvailable("io7nm8wWi6uOqeKa49/vVsHch3zVbT8RV94d9/w0jiyOd8Rsk//U8UlralVsbjYRhOg3dJvhuwyoSUpEFh11MMzH09nbgV61");
        }
    }
}
