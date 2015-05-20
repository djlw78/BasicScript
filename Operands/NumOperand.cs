using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class NumOperand : Operand
    {
        private object value;

        internal NumOperand(object value)
        {
            this.value = value;
        }

        internal object GetValue()
        {
            return this.value;
        }
    }
}
