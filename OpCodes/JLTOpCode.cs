using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class JLTOpCode : OpCode
    {
        private const int expectedOperandCount = 3;

        internal JLTOpCode(Operand[] operands, MemoryStore store)
            : base(operands, store)
        {
        }

        internal override void Execute()
        {
            var ident = this.operands[0] as IdentOperand;
            var num = this.operands[1] as NumOperand;
            var label = this.operands[2] as LabelIdentOperand;

            var storedValue = Convert.ToInt32(this.store.Get(ident));

            if (storedValue < Convert.ToInt32(num.GetValue()))
            {
                // If the stored value is less than the given number.
                // Get the PC counter for the label.
                var pc = Convert.ToInt32(store.Get(label));

                // Set the PC equal to the stored value so we start executing there.
                Globals.PC = pc;
            }
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

            if (operands[1].GetType() != typeof(NumOperand))
            {
                throw new Exception("Operand 1 not type NUM");
            }

            if (operands[2].GetType() != typeof(LabelIdentOperand))
            {
                throw new Exception("Operand 2 not type LABEL");
            }
        }
    }
}
