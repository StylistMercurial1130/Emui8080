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

        public Emulator()
        {
            m_8080Context = new _8080();
            m_Registerset = new Register();
            m_Flags = new Flags();
        }


        public delegate void Del();

        public void PrintDelegateTest()
        {
            Console.WriteLine("Printing from invoking a delegate function ! ");
        }

        public void EmulationMain(string[] args)
        {
            Console.WriteLine("You have reached the emuation main function ! ");


            for (int i = 0; i < 10; i++)
                m_8080Context.Store(0x0, (ushort)i);
            
            while(m_8080Context.pc < 10)
            {
                m_8080Context.pc += m_8080Context.Dissasemble();
            }

        }
    }
}
