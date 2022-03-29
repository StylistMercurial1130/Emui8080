using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8080_Emulator.Intel8080;

namespace _8080_Emulator._8080Emulator
{
    internal class Disassembler
    {

        private delegate ushort MachineInstruction(ref _8080 i8080Context, ref Register register, ref Flags flags);
        private Dictionary<byte, MachineInstruction> jumpTable;  
        private ushort MachineInstructionNOP(ref _8080 i8080Context,ref Register register,ref Flags flags)
        {
            Console.WriteLine("NOP");
            return 1;
        }

        private ushort MachineInstructionLXIB(ref _8080 i8080Context, ref Register register, ref Flags flags)
        {
            byte low = i8080Context.Fetch((ushort)(i8080Context.pc + 1));
            byte high = i8080Context.Fetch((ushort)(i8080Context.pc + 2));

            register.registerB.high = low;
            register.registerB.low = high;

            Console.WriteLine("LXI B , {0:X}",register.registerB.JointRegisterValue());

            return 3;
        }

        private ushort MachineInstructionSTAXB(ref _8080 i8080Context, ref Register register, ref Flags flags)
        {
            ushort address = register.registerB.JointRegisterValue();
            i8080Context.Store(register.registerA.low, address);

            Console.WriteLine("STAX B");

            return 1;
        }

        private ushort MachineInstructionINXB(ref _8080 i8080Context, ref Register register, ref Flags flags)
        {

            ushort value = register.registerB.JointRegisterValue();
            value += 1;

            byte low = (byte)(value & 0xFF);
            byte high = (byte)(value >> 8);

            register.registerB.low = low;
            register.registerB.high = high;

            Console.WriteLine("INX B ; B value is {0:X}",register.registerB.JointRegisterValue());

            return 1;
        }

        public Disassembler()
        {
            jumpTable = new Dictionary<byte, MachineInstruction>();

            jumpTable.Add(0x0,MachineInstructionNOP);
            jumpTable.Add(0x1,MachineInstructionLXIB);
            jumpTable.Add(0x2,MachineInstructionSTAXB);
            jumpTable.Add(0x3,MachineInstructionINXB);

        }

        public void DissasembleInstruction(ref _8080 i8008Context, ref Register register, ref Flags flags) =>
            i8008Context.pc += 
                jumpTable[i8008Context.Fetch(i8008Context.pc)].Invoke(ref i8008Context,ref register,ref flags);
        




    }
}
