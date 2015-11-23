﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans.TestingHost;
using Lesson2aGrainInterfaces;

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
        public async void BuildGrainTest()
        {
            var grain = GrainFactory.GetGrain<IPerson>("Bill Llama");

            // This will create and call a Hello grain with specified 'id' in one of the test silos.
            await grain.Listen("peter piper picked a pick of peppers");
        }

        [TestMethod]
        public async void IHeardPeterTest()
        {
            var grain = GrainFactory.GetGrain<IPerson>("Bill Llama");

            var words = await grain.GetReality();

            Assert.AreEqual<string>("peter piper picked a pick of peppers", words);
        }

    }
}
