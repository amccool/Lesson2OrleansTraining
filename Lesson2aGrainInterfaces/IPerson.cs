using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2aGrainInterfaces
{
    public interface IPerson : IGrainWithStringKey
    {
        Task Listen(string sentence);

        Task<string> GetReality();
    }
}
