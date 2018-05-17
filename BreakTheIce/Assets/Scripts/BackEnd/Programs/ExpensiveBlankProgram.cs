using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BackEnd.Programs
{
    public class ExpensiveBlankProgram : Program
    {
        public ExpensiveBlankProgram() : base("Expensive Blank Card", 2, "Does Nothing", (r) => { })
        {
        }
    }
}
