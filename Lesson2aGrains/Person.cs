using Lesson2aGrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2aGrains
{
    public class Person : Grain, IPerson
    {
        public Task<string> GetReality()
        {
            return Task.FromResult("ggggg");
        }

        public Task Listen(string sentence)
        {
            return TaskDone.Done;
        }
    }
}
