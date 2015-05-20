using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class SetOpCode : OpCode
    {
        private const int expectedOperandCount = 2;

        internal SetOpCode(Operand[] operands, MemoryStore store)
            : base(operands, store)
        {
        }

        internal override void Execute()
        {
            var ident = this.operands[0] as IdentOperand;
            var num = this.operands[1] as NumOperand;

            // Provision the identity with a null value
            store.Set(ident, num.GetValue());
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
        }
    }
}
