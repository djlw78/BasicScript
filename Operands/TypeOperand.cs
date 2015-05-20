using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class TypeOperand : Operand
    {
        private TYPE identType;

        internal TypeOperand(TYPE identType)
        {
            this.identType = identType;
        }
    }
}
