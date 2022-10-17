using System;
using PTSLibrary;
using System.Runtime.Remoting;


namespace RemoteServerApplication
{
    class Program
    {
        private static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(50000);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PTSAdminFacade), "PTSAdminFacade", WellKnownObjectMode.Singleton);

           



            Console.WriteLine("Press the enter key to terminate service");
            Console.ReadLine();
        }
    }
}