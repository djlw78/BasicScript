using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleScript.OpCodes;

namespace SimpleScript
{
    class Tests
    {
        internal void TestDef()
        {
            IdentOperand id = new IdentOperand("A");
            TypeOperand typeOp = new TypeOperand(TYPE.INT);

            Operand[] operands = new Operand[] { id, typeOp };
            MemoryStore store = new MemoryStore();

            DefOpCode op = new DefOpCode(operands, store);
            op.Execute();

            var storedValue = store.Get(id);

            if (storedValue != null)
            {
                throw new Exception("Stored value should have been null");
            }

            id = new IdentOperand("@A");
            operands = new Operand[] { id, typeOp };

            bool noAtSignsPassed = false;
            try
            {
                op = new DefOpCode(operands, store);
                op.Execute();
            }
            catch (Exception ex)
            {
                noAtSignsPassed = true;
            }

            if (noAtSignsPassed == false)
            {
                throw new Exception("Expected Def.Execute to fail with @ in IDENT name.");
            }
        }

        internal void TestSet()
        {
            MemoryStore store = new MemoryStore();

            IdentOperand id = new IdentOperand("A");
            TypeOperand typeOp = new TypeOperand(TYPE.INT);
            NumOperand num = new NumOperand(10);

            // We must define the variable prior to using it
            DefOpCode defOp = new DefOpCode(new Operand[] { id, typeOp }, store);
            defOp.Execute();

            Operand[] operands = new Operand[] { id, num };

            SetOpCode setOp = new SetOpCode(operands, store);
            setOp.Execute();

            var storedValue = Convert.ToInt32(store.Get(id));

            if (storedValue != 10)
            {
                throw new Exception("Stored value != 10");
            }
        }

        internal void TestAdd()
        {
            MemoryStore store = new MemoryStore();

            IdentOperand idA = new IdentOperand("A");
            IdentOperand idB = new IdentOperand("B");
            IdentOperand idC = new IdentOperand("C");

            TypeOperand typeOp = new TypeOperand(TYPE.INT);

            NumOperand numA = new NumOperand(10);
            NumOperand numB = new NumOperand(20);


            // We must define the variable prior to using it
            DefOpCode defOp = new DefOpCode(new Operand[] { idA, typeOp }, store);
            defOp.Execute();

            defOp = new DefOpCode(new Operand[] { idB, typeOp }, store);
            defOp.Execute();

            defOp = new DefOpCode(new Operand[] { idC, typeOp }, store);
            defOp.Execute();

            // Store A
            Operand[] operands = new Operand[] { idA, numA };
            SetOpCode op = new SetOpCode(operands, store);
            op.Execute();

            // Store B
            operands = new Operand[] { idB, numB };
            op = new SetOpCode(operands, store);
            op.Execute();

            // Add: C = A + B
            AddOpCode addOp = new AddOpCode(new Operand[] { idC, idA, idB }, store);
            addOp.Execute();

            var storedValue = Convert.ToInt32(store.Get(idC));

            if (storedValue != 30)
            {
                throw new Exception("Stored value != 30");
            }
        }

        internal void TestPrint()
        {
            MemoryStore store = new MemoryStore();

            IdentOperand idA = new IdentOperand("A");
            TypeOperand typeOp = new TypeOperand(TYPE.INT);

            NumOperand numA = new NumOperand(10);


            // We must define the variable prior to using it
            DefOpCode defOp = new DefOpCode(new Operand[] { idA, typeOp }, store);
            defOp.Execute();


            // Store A
            Operand[] operands = new Operand[] { idA, numA };
            SetOpCode op = new SetOpCode(operands, store);
            op.Execute();

            PrintOpCode printOp = new PrintOpCode(new Operand[] { idA }, store);
            printOp.Execute();
        }
    }
}
