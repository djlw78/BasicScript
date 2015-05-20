using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class AddOpCode : OpCode
    {
        private const int expectedOperandCount = 3;

        internal AddOpCode(Operand[] operands, MemoryStore store)
            : base(operands, store)
        {
        }

        internal override void Execute()
        {
            var identDest = this.operands[0] as IdentOperand;
            var identAdd1 = this.operands[1] as IdentOperand;
            var identAdd2 = this.operands[2] as IdentOperand;

            int val1 = Convert.ToInt32(store.Get(identAdd1));
            int val2 = Convert.ToInt32(store.Get(identAdd2));

            int res = val1 + val2;

            NumOperand num = new NumOperand(res);
            
            SetOpCode setOp = new SetOpCode(new Operand[] { identDest, num }, store);
            setOp.Execute();
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

            if (operands[1].GetType() != typeof(IdentOperand))
            {
                throw new Exception("Operand 1 not type IDENT");
            }

            if (operands[2].GetType() != typeof(IdentOperand))
            {
                throw new Exception("Operand 2 not type IDENT");
            }
        }
    }
}
