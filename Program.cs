using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleScript.OpCodes;

namespace SimpleScript
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStore memStore = new MemoryStore();
            OpCode[] opCodes = new OpCode[]
            {
               new DefOpCode(
                        new Operand[] { new IdentOperand("A"), new TypeOperand(TYPE.INT) },
                        memStore),
               new SetOpCode(
                        new Operand[] { new IdentOperand("A"), new NumOperand(10) },
                        memStore),
               new DefOpCode(
                        new Operand[] { new IdentOperand("B"), new TypeOperand(TYPE.INT) },
                        memStore),
               new SetOpCode(
                        new Operand[] { new IdentOperand("B"), new NumOperand(10) },
                        memStore),
               new LabelOpCode(
                        new Operand[] { new IdentOperand("Label1") },
                        memStore),
               new AddOpCode(
                        new Operand[] { new IdentOperand("A"), new IdentOperand("A"), new IdentOperand("B") },
                        memStore),
               new PrintOpCode(
                        new Operand[] { new IdentOperand("A") },
                        memStore),
               new JLTOpCode(new Operand[] { new IdentOperand("A"), new NumOperand(100), new LabelIdentOperand("Label1") },
                        memStore),
               new ExitOpCode(
                        null,
                        memStore),
            };

            Globals.PC = -1;
            do
            {
                ++Globals.PC;
                opCodes[Globals.PC].Execute();
            }
            while (Globals.PC >= 0);

            //Tests t = new Tests();
            //t.TestDef();
            //t.TestSet();
            //t.TestAdd();
            //t.TestPrint();
        }
    }
}
