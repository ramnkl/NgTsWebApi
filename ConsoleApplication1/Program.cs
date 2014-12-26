using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NgTs.BusinessLogic;
using NgTs.Entities;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            NgTsUserManager mgr = new NgTsUserManager();
            NgTsUser u = new NgTsUser();
            u.FirstName = "dddd";
            u.LastName = "lastn";
            u.Password = "p";
            u.UserCode = "usercode";
            mgr.CreateNgTsUser(u);
            

        }
    }
}
