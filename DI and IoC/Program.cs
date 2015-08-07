using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Ninject;
namespace DI_and_IoC
{
    public interface IMaster
    {
        void MasterCall();
    }
    public class Master : IMaster
    {
        public void MasterCall()
        {
            Console.WriteLine("Back To Work!!!");
        }
    }

    public class Slave
    {
        IMaster chief = null;
        public Slave(IMaster master)
        {
            chief = master;
        }

        public void SlaveWork()
        {
            chief.MasterCall();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel();
            kernal.Bind<IMaster>().To<Master>();

            var slave1 = kernal.Get<Slave>();
            slave1.SlaveWork();

            var slave2 = kernal.Get<Slave>();
            slave2.SlaveWork();

            Console.ReadLine();
        }
    }
}