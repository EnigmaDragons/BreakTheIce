using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BackEnd.Programs
{
    public class BlankProgram : Program
    {
        public BlankProgram() : base("Blank Card", 0, "Does Nothing", () => { })
        {
        }
    }
}
