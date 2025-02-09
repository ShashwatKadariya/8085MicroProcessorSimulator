namespace _8085Simulator.Core.Components;

public class Registers
{
    private Dictionary<string, byte> _registers;

    public Registers()
    {
        _registers = new()
        {
            { "A", 0 },   // Accumulator
            { "B", 0 },   // General Purpose
            { "C", 0 },   // General Purpose
            { "D", 0 },   // General Purpose
            { "E", 0 },   // General Purpose
            { "H", 0 },   // High address
            { "L", 0 }    // Low address
        };
    }

    public byte this[string register]
    {
        get => _registers[register.ToUpper()];
        set => _registers[register.ToUpper()] = value;
    }

    public (byte H, byte L) GetHL() => (_registers["H"], _registers["L"]);
}