namespace _8085Simulator.Core.Components;

public class FlagRegister
{
    private byte _flags;

    public bool Sign
    {
        get => (_flags & 0x80) != 0;
        set => _flags = (byte)(value ? _flags | 0x80 : _flags & ~0x80);
    }

    public bool Zero
    {
        get => (_flags & 0x40) != 0;
        set => _flags = (byte)(value ? _flags | 0x40 : _flags & ~0x40);
    }

    public bool AuxiliaryCarry
    {
        get => (_flags & 0x10) != 0;
        set => _flags = (byte)(value ? _flags | 0x10 : _flags & ~0x10);
    }

    public bool Parity
    {
        get => (_flags & 0x04) != 0;
        set => _flags = (byte)(value ? _flags | 0x04 : _flags & ~0x04);
    }

    public bool Carry
    {
        get => (_flags & 0x01) != 0;
        set => _flags = (byte)(value ? _flags | 0x01 : _flags & ~0x01);
    }

    public void UpdateFlags(byte result)
    {
        Sign = (result & 0x80) != 0;
        Zero = result == 0;
        Parity = CountSetBits(result) % 2 == 0;
    }

    private static int CountSetBits(byte n)
    {
        int count = 0;
        while (n != 0)
        {
            count += n & 1;
            n >>= 1;
        }
        return count;
    }
}