using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Dominik
{
    class Program
    {
        static void Main(string[] args)
        {
            var identity = WindowsIdentity.GetCurrent();
            Console.WriteLine(identity.User); //SIDs
            Console.WriteLine(identity.Name); //UserName with PC Domain

            var principle = new WindowsPrincipal(identity);
            Console.WriteLine("Is in Users Role " + principle.IsInRole("Builtin\\Users") );

            var account = new NTAccount(identity.Name);
            var sid = account.Translate(typeof(SecurityIdentifier));
            write(sid.Value); //Another way to fetch SID

            Console.ReadLine();
        }

        private static void write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
