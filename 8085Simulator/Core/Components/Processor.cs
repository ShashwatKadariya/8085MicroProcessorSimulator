namespace _8085Simulator.Core.Components;

    public class Processor
    {
        private readonly Registers _registers;
        private readonly FlagRegister _flags;
        private readonly Memory _memory;
        private ushort _programCounter;
        private ushort _stackPointer;

        public Processor()
        {
            _registers = new Registers();
            _flags = new FlagRegister();
            _memory = new Memory();
            _programCounter = 0;
            _stackPointer = 0xFFFF;
        }

        public void LoadProgram(byte[] program, ushort startAddress = 0)
        {
            for (int i = 0; i < program.Length; i++)
            {
                _memory[(ushort)(startAddress + i)] = program[i];
            }
            _programCounter = startAddress;
        }

        public void ExecuteNextInstruction()
        {
            byte opcode = _memory[_programCounter++];
            ExecuteOpcode(opcode);
        }

        private void ExecuteOpcode(byte opcode)
        {
            switch (opcode)
            {
                case 0x00: // NOP - No operation (Ignore it and continue)
                    return;
                case 0x3E: // MVI A, data
                    _registers["A"] = _memory[_programCounter++];
                    break;

                case 0x77: // MOV M, A
                    var (h, l) = _registers.GetHL();
                    _memory[h, l] = _registers["A"];
                    break;

                case 0x87: // ADD A
                    Add(_registers["A"]);
                    break;
                

                default:
                    throw new NotImplementedException($"Opcode {opcode:X2} not implemented");
            }
        }

        private void Add(byte value)
        {
            int result = _registers["A"] + value;
            _flags.Carry = result > 0xFF;
            _flags.AuxiliaryCarry = (_registers["A"] & 0x0F) + (value & 0x0F) > 0x0F;
            _registers["A"] = (byte)result;
            _flags.UpdateFlags(_registers["A"]);
        }

        public (byte A, byte B, byte C, byte D, byte E, byte H, byte L) GetRegisterState() =>
            (_registers["A"], _registers["B"], _registers["C"], 
             _registers["D"], _registers["E"], _registers["H"], _registers["L"]);

        public FlagRegister GetFlags() => _flags;
    }