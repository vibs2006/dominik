using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;
using System.Security.Claims;

namespace Dominik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.Name, "Vaibhav"),
               new Claim(ClaimTypes.Email, "cutevibhor@gmail.com"),
               new Claim(ClaimTypes.Role, "Admin")
           };

            ClaimsIdentity identity = new ClaimsIdentity(claims,"any identity", ClaimTypes.Name, ClaimTypes.Role);
            var priciple = new ClaimsPrincipal(identity);

            corporateIdentity identityCorp = new corporateIdentity("vaibhav", "vaibhavreports", "office");
            Console.WriteLine("Corp - " + identity.Name);

            //ClaimsPrincipal.Current is also used 


            Thread.CurrentPrincipal = priciple;

            Console.WriteLine(identity.IsAuthenticated);

            Console.WriteLine(Thread.CurrentPrincipal.Identity.Name);

            var claimprinciple1 =  (ClaimsPrincipal)(Thread.CurrentPrincipal);
            foreach (var item in claimprinciple1.Claims)
                Console.WriteLine(item.Type + " - " + item.Value);

            //Fetch record from identity
            Console.WriteLine(claimprinciple1.FindFirst(ClaimTypes.Email).Value);


            Console.ReadLine();
        }
    }

    class corporateIdentity: ClaimsIdentity
    {
        public corporateIdentity(string name, string reportsTo, string office)
        {
            AddClaim(new Claim(ClaimTypes.Name, name));
            AddClaim(new Claim("reportsTo", reportsTo));
        }
      

        public string Job { get; set; }
    }
}
