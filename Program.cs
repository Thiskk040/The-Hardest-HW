using System;
using System.Collections.Generic;

namespace _62
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("InputCpuCoreData");
            Console.WriteLine();
            Console.WriteLine("When you insert all cpu core input c to calculate");
            Console.WriteLine();
            List<Value> inputvalue = new List<Value>();


            while (true)
            {

                string InputIntruction = Console.ReadLine(); 
                if (InputIntruction == "c")
                {
                    calculate(inputvalue);
                    break; 
                }
                else
                {
                    inputvalue.Add(InputCpuProcessor(InputIntruction));
                }
            }

        }


        static Value InputCpuProcessor(string value)
        {
            Console.Write(" "); 
            string Intruction = Console.ReadLine();
            Console.Write(" "); 
            string Data = Console.ReadLine();

            Value inputValue = new Value(); 
            inputValue.Instruction = Intruction; 
            inputValue.Data = Data; 
            return inputValue; 
        }

        static void calculate(List<Value> inputvalue,int CpuCycleCount = 0)
        {
           
            
            List<Value> waitfordata = new List<Value>();
            CpuCore[] cpu = new CpuCore[4];
            CpuCycleCount++;


            for (int x = 0; x < cpu.Length; x++)
            {
                cpu[x] = new CpuCore();
            }
            for (int i = 0; i < inputvalue.Count; i++)
            {
                string instruction = inputvalue[i].Instruction;
                for (int j = 0; j < cpu.Length; j++)
                {

                    if (cpu[j].CpuInstruction == null || cpu[j].CpuInstruction == instruction)
                    {
                        cpu[j].CpuInstruction = instruction;

                        for (int y = 0; y < cpu[j].CpuData.Length;y++)
                        {
                            if (cpu[j].CpuData[y] == null || cpu[j].CpuData[y] == inputvalue[i].Data)
                            {
                                cpu[j].CpuData[y] = inputvalue[i].Data;
                                break;
                            }
                            else if (y == cpu[j].CpuData.Length - 1)
                            {
                                waitfordata.Add(inputvalue[i]);
                                break;
                            }

                        }
                        break;
                    }
                    else if (j == cpu.Length - 1)
                    {
                        waitfordata.Add(inputvalue[i]);

                    }

                }
            }
            if(waitfordata.Count>0)
            {
                calculate(waitfordata, CpuCycleCount);
            }
            else
            {
                Console.WriteLine("Cpu cycles need: " + CpuCycleCount);
            }


        }
    }
}
