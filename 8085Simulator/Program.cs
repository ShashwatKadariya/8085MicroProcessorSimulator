using System;
using System.Collections.Generic;
using System.Linq;
using _8085Simulator.Core.Components;

namespace _8085Simulator;

    public class Program
    {
        
        static void RunExample(string name, byte[] program)
        {
            Console.WriteLine($"\n=== {name} ===");
            var processor = new Processor();
            processor.LoadProgram(program);

            Console.WriteLine("Initial state:");
            PrintState(processor);

            Console.WriteLine("\nExecuting instructions:");
            foreach (var _ in program)
            {
                processor.ExecuteNextInstruction();
                PrintState(processor);
            }
        }

        static void PrintState(Processor processor)
        {
            var (a, b, c, d, e, h, l) = processor.GetRegisterState();
            var flags = processor.GetFlags();
            Console.WriteLine($"Registers: A:{a:X2} B:{b:X2} C:{c:X2} D:{d:X2} E:{e:X2} H:{h:X2} L:{l:X2}");
            Console.WriteLine($"Flags: S:{flags.Sign} Z:{flags.Zero} AC:{flags.AuxiliaryCarry} P:{flags.Parity} C:{flags.Carry}");
        }

        
        // Implemented INstructions
        /*
         
         0x00 -> NOP -> No-Operations
         0x3E -> MVI A, data -> loads into register A
         0x77 -> MOV M, A -> Store A into memory at address in HL
         0x87 -> ADD A -> Add A to itself
         
         */
        
        
        
        public static void Main()
        {
            // Addition Operation Example
            byte[] additionProgram = {
                0x3E, 0x05,     // MVI A, 05    
                0x87            // ADD A        
            };
            RunExample("Addition Program (5+5)", additionProgram);

            // Memory Operation Example
            byte[] memoryProgram = {
                0x3E, 0xFF,     // MVI A, FF
                0x77            // MOV M, A  
            };
            RunExample("Memory Operation (Store FF)", memoryProgram);
            

            // Multiple Additions Example
            byte[] multipleAdditions = {
                0x3E, 0x03,     // MVI A, 03
                0x87,           // ADD A          
                0x87            // ADD A         
            };
            RunExample("Multiple Additions (3->6->12)", multipleAdditions);

            // Random Example: Move 2 into register A
            byte[] testExample =
            {
                0x3E, 0x02
            };
            RunExample("Test Example", testExample);
        }
    }