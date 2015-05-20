using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleScript.OpCodes;

namespace SimpleScript
{
    class MemoryStore
    {
        private Dictionary<string, Object> memStore = new Dictionary<string, object>();

        internal void Define(IdentOperand memLocation)
        {
            var identString = memLocation.ToString();

            if(this.memStore.ContainsKey(identString))
            {
                throw new Exception(string.Format("Cannot redefine {0}", identString));
            }

            this.memStore.Add(identString, null);
        }

        internal void Set(IdentOperand memLocation, Object value)
        {
            var identString = memLocation.ToString();

            if (!this.memStore.ContainsKey(identString))
            {
                throw new Exception(string.Format("{0} is not defined", identString));
            }
            else
            {
                this.memStore[identString] = value;
            }
        }

        internal Object Get(IdentOperand memLocation)
        {
            var identString = memLocation.ToString();

            object storedVal;
            if (!this.memStore.TryGetValue(identString, out storedVal))
            {
                throw new Exception(
                            string.Format("Unable to find value for {0} in memstore",
                            identString)
                       );
            }

            return storedVal;
        }
    }
}
