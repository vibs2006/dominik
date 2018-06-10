using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;

namespace Dominik
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var identity = WindowsIdentity.GetCurrent();
            //Console.WriteLine(identity.User); //SIDs
            //Console.WriteLine(identity.Name); //UserName with PC Domain

            //var principle = new WindowsPrincipal(identity);
            //Console.WriteLine("Is in Users Role " + principle.IsInRole("Builtin\\Users"));

            //var account = new NTAccount(identity.Name);
            //var sid = account.Translate(typeof(SecurityIdentifier));
            //write(sid.Value); //Another way to fetch SID

            //write("Groups (SIDs) - (Their Name Transaction Account)");
            //foreach (var group in identity.Groups)
            //{
            //    write($"({group.Value}) - ({group.Translate(typeof(NTAccount))})");
            //}

            ////You need to run this in elevated command prompt otherwise it'll return false.
            //var localAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            //write($"Is in Built in Local Administrator role? - {principle.IsInRole(localAdmins)}");

            //var localAdmins1 = new SecurityIdentifier(WellKnownSidType.AccountAdministratorSid, identity.User.AccountDomainSid);
            //write($"Is in Account Administrator role? - {principle.IsInRole(localAdmins1)}");

            SetupPrincipal();
            UsePrincipal();


            Console.ReadLine();
        }

        private static void write(string s)
        {
            Console.WriteLine(s);
        }

        private static void SetupPrincipal()
        {
            var identity = new GenericIdentity("bob");

            string[] roles = new string[] { "admin" };

            var genericprinciple = new GenericPrincipal(identity, roles);

            Thread.CurrentPrincipal = genericprinciple;

        }
        //Error must be handled
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Developer")] //You can use multiple roles like this
        private static void AdminSpecificTask()
        {
            write("Admin Specific Task performed");
        }

        private static void UsePrincipal()
        {
            var principle = Thread.CurrentPrincipal;

            write(principle.Identity.Name);
            write(principle.Identity.IsAuthenticated.ToString());
            write(principle.IsInRole("admin").ToString());

            //Three approaches for a deciding ona  role type. 

            //Approach 1
            if (principle.IsInRole("admin"))
            {
                write("Role is Admin");
            }

            //If this fails then it'll raise exception and you need to catch that
            new PrincipalPermission(null, "Admin").Demand();
            write("Role passed principle permission so must be fine");

            //Third Aproach
            AdminSpecificTask();
        }
    }
}
