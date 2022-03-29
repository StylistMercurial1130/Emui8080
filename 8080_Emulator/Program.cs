using _8080_Emulator._8080Emulator;
namespace emulatorApplication
{
    class Program
    {
  
        public static Emulator Emulator;
        static Program() => Emulator = new Emulator();
        // entry point of the applciation !
        public static void Main(string[] args) => Emulator.EmulationMain(args);
       
    }
}