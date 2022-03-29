using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace _8080_Emulator.Intel8080
{

    struct m_Register
    {
        private byte _low, _high;

        public byte low { get { return _low; }  set { this._low = value; } }
        public byte high { get { return _high; } set { this._high = value; } }

        public ushort JointRegisterValue() => (ushort)((high << 8) | low);

    };

    internal class Register
    {
        
        public m_Register registerB;
        public m_Register registerH;
        public m_Register registerD;
        public m_Register registerA;

        public Register()
        {
            registerB = new m_Register();
            registerH = new m_Register();
            registerA = new m_Register();
            registerD = new m_Register();

            registerA.low = 0;
            registerB.low = registerB.high = 0;
            registerH.low = registerH.high = 0;
            registerD.low = registerD.high = 0;

        }
    }
}
