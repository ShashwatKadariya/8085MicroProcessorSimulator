namespace _8085Simulator.Core.Components;

public class Memory
{
    private readonly byte[] _memory = new byte[65536];  // 64K memory

    public byte this[ushort address]
    {
        get => _memory[address];
        set => _memory[address] = value;
    }

    public byte this[byte high, byte low]
    {
        get => _memory[(ushort)((high << 8) | low)];
        set => _memory[(ushort)((high << 8) | low)] = value;
    }
}