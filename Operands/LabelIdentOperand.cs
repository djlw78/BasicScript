using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript.OpCodes
{
    class LabelIdentOperand : IdentOperand
    {
        internal LabelIdentOperand(string name)
            : base(name)
        {
        }
    }
}
