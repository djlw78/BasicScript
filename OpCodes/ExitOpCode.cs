using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class ExitOpCode : OpCode
    {
        internal ExitOpCode(Operand[] operands, MemoryStore store)
            : base(operands, store)
        {
        }

        internal override void Execute()
        {
            Globals.PC = -1;
        }

        protected override void Validate(Operand[] operands)
        {
        }
    }
}
