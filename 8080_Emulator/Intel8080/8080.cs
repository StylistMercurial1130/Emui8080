using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8080_Emulator.Intel8080
{
    internal class _8080
    {
        public ushort pc { get; set; }
        public ushort sp { get; set; }
        private byte[] memory = new byte[0x10000];
        public _8080() => pc = sp = 0x0;
        public void SetProgramCounter(ushort pc) => this.pc = pc;
        public void SetStackPointer(ushort sp) => this.sp = sp;
        public byte Store(byte value, ushort index) => memory[index] = value;
        public byte Fetch(ushort index) => (byte)memory[index];

        public ushort Dissasemble()
        {
            byte opcode = memory[pc];
            ushort byte_jump = 1;
            switch (opcode)
            {
                case 0x0:
                    Console.WriteLine("NOP");
                    break;
                case 0x1:
                    Console.WriteLine($"LXI , B , {memory[pc + 1]} ");
                    byte_jump = 3;
                    break;
                case 0x2:
                    Console.WriteLine($"STAX B");
                    byte_jump = 1;
                    break;
                case 0x3:
                    Console.WriteLine($"INX B");
                    byte_jump = 1;
                    break;
                case 0x4:
                    Console.WriteLine($"INR B");
                    byte_jump = 1;
                    break;
                case 0x5:
                    Console.WriteLine($"DCR B");
                    byte_jump = 1;
                    break;
                case 0x6:
                    Console.WriteLine($"MVI B , {memory[pc + 1]}");
                    break;

            }

            return byte_jump;
        }

    }
}
  
