using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8080_Emulator.Intel8080;

namespace _8080_Emulator._8080Emulator
{
    internal class Emulator
    {
        private _8080 m_8080Context;
        private Register m_Registerset;
        private Flags m_Flags;
        private Disassembler m_Disassembler;

        public Emulator()
        {
            m_8080Context = new _8080();
            m_Registerset = new Register();
            m_Flags = new Flags();
            m_Disassembler = new Disassembler();
        }


        public delegate void Del();

        public void PrintDelegateTest()
        {
            Console.WriteLine("Printing from invoking a delegate function ! ");
        }

        public void EmulationMain(string[] args)
        {
            Console.WriteLine("You have reached the emuation main function ! ");

            m_8080Context.Store(0x1, (ushort)0);
            m_8080Context.Store(0x38, (ushort)1);
            m_8080Context.Store(0xFF, (ushort)2);
            m_8080Context.Store(0x3,(ushort)3);

            while(m_8080Context.pc < 4)    
            {   
                m_Disassembler.DissasembleInstruction(ref m_8080Context,ref m_Registerset,ref m_Flags);
            }

        }
    }
}
