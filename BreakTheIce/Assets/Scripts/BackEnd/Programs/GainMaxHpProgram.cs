using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BackEnd.Programs
{
    public class GainMaxHpProgram : Program
    {
        public GainMaxHpProgram() : base("Gain Max HP", 1, "Gives you 1 max hp", (r) => { r.GainMaxHp(1); })
        {
        }
    }
}
