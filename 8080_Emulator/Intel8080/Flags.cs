using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace _8080_Emulator.Intel8080
{
    internal class Flags
    {
        private byte m_Flag;
        public byte carryBit
        {
            get => (byte)(m_Flag & 0x01);
            set => m_Flag = (byte)((m_Flag & 0xFE) | value);
        }

        public byte AuxilaryBit
        {
            get => (byte)((m_Flag & 0x2) >> 1);
            set => m_Flag = (byte)((m_Flag & 0xFD) | (value << 1));
        }

        public byte signBit
        {
            get => (byte)((m_Flag & 0x4) >> 2);
            set => m_Flag = (byte)((m_Flag & 0xFB) | (value << 2));
        }

        public byte SignBit
        {
            get => (byte)((m_Flag & 0x8) >> 3);
            set => m_Flag = (byte)((m_Flag & 0xF7) | (value << 3));
        }

        public byte zeroBit
        {
            get => (byte)((m_Flag & 0x10) >> 4);
            set => m_Flag = (byte)((m_Flag & 0xF) | (value << 4));
        }

        public Flags()
        {
            m_Flag = 0x0;
        }
    }
}
