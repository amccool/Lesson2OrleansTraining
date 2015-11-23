using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans.TestingHost;

namespace OrleansBasicUnitTests
{
    [TestClass]
    public class TalkingUnitTest : TestingSiloHost
    {
        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Optional. 
            // By default, the next test class which uses TestignSiloHost will
            // cause a fresh Orleans silo environment to be created.
            StopAllSilos();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
