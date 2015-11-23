using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans.TestingHost;
using Lesson2aGrainInterfaces;
using System.IO;

namespace OrleansBasicUnitTests
{
    [DeploymentItem("OrleansConfigurationForTesting.xml")]
    [DeploymentItem("ClientConfigurationForTesting.xml")]
    [DeploymentItem("OrleansProviders.dll")]
    [DeploymentItem("Lesson2aGrains.dll")]
    [TestClass]
    public class TalkingUnitTest : TestingSiloHost
    {
        public TalkingUnitTest()
            : base(new TestingSiloOptions
            {
                StartFreshOrleans = true,
                SiloConfigFile = new FileInfo("OrleansConfigurationForTesting.xml"),
            },
            new TestingClientOptions()
            {
                ClientConfigFile = new FileInfo("ClientConfigurationForTesting.xml")
            })
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Optional. 
            // By default, the next test class which uses TestignSiloHost will
            // cause a fresh Orleans silo environment to be created.
            StopAllSilos();
        }

        [TestMethod]
        public void BuildGrainTest()
        {
            var grain = GrainFactory.GetGrain<IPerson>("Bill Llama");

            // This will create and call a Hello grain with specified 'id' in one of the test silos.
            grain.Listen("peter piper picked a pick of peppers").Wait();
        }

        [TestMethod]
        public void IHeardPeterTest()
        {
            var grain = GrainFactory.GetGrain<IPerson>("Bill Llama");

            var words = grain.GetReality();
            words.Wait();

            Assert.AreEqual<string>("peter piper picked a pick of peppers", words.Result);
        }

    }
}
