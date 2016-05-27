using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopwinLaser2016.Power
{
    public enum POWER
    {
        OPERATPR    = 0,
        ENGINEER    = 1,
        ADMIN       = 2,
        TOPWIN      = 3,


        SW          = Int32.MaxValue,
    }

    public class Power
    {
        public static POWER Access = POWER.OPERATPR;


        public static bool CheckPower(POWER power, string code, string access = "")
        {
            bool res = true;

            Access = power;
            return res;
        }

        public static bool ChangePowerCode(POWER power, string oldCode, string newCode)
        {
            bool res = true;

            return res;
        }
    }
}
