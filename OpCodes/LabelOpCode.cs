using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class LabelOpCode : OpCode
    {
        private const int expectedOperandCount = 1;

        internal LabelOpCode(Operand[] operands, MemoryStore store)
            : base(operands, store)
        {
        }

        internal override void Execute()
        {
            var ident = this.operands[0] as IdentOperand;

            // We need to define the label name as a variable
            DefOpCode defOp = new DefOpCode(new Operand[] { ident, new TypeOperand(TYPE.LABEL) }, store);
            defOp.Execute();

            // Store the label Name as a variable and the value is the current line.
            // It is important to use the current line, becasue the PC is always incremented before
            // the next instruction is executed. If we used the next line, then the next line would
            // continuously be skipped.
            // A jump will then set the PC counter to this value for execution.
            store.Set(ident, Globals.PC);
        }

        protected override void Validate(Operand[] operands)
        {
            if (operands.Count() != expectedOperandCount)
            {
                throw new Exception(
                        string.Format("Expected {0} operands, found {1}",
                                      expectedOperandCount,
                                      operands.Count()
                                     )
                    );
            }

            if (operands[0].GetType() != typeof(IdentOperand))
            {
                throw new Exception("Operand 0 not type IDENT");
            }
        }
    }
}
