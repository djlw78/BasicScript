using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript
{
    enum OpsCodes
    {
        DEF,
        SET,
        ADD,
        LABEL,
        PRINT,
        LOAD,
        JGT
    }

    abstract class OpCode
    {
        internal Operand[] operands = null;
        internal MemoryStore store = null;

        internal OpCode(Operand[] operands, MemoryStore store)
        {
            this.operands = operands;
            this.store = store;

            this.Validate(operands);
        }

        protected abstract void Validate(Operand[] operands);
        internal abstract void Execute();
    }
}
