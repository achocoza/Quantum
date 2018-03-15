#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.BELL", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs", 160L, 7L, 5L)]
[assembly: OperationDeclaration("Quantum.BELL", "BellTest (count : Int, initial : Result) : (Int, Int)", new string[] { }, "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs", 375L, 20L, 5L)]
#line hidden
namespace Quantum.BELL
{
    public class Set : Operation<(Result,Qubit), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Result,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.BELL.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (desired,q1) = _args;
#line 10 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    var current = M.Apply<Result>(q1);
                    // measure
#line 12 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    if ((desired != current))
                    {
#line 14 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        MicrosoftQuantumPrimitiveX.Apply(q1);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.BELL.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64)>
    {
        public BellTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.BELL.Set) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Result,Qubit), QVoid>, Quantum.BELL.Set>();
            }
        }

        public override Func<(Int64,Result), (Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.BELL.BellTest", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64));
                try
                {
                    var (count,initial) = _args;
#line 23 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    var numOnes = 0L;
                    // a mutable variable can change using a set statement
                    // using (qubits = Qubit[1]) // the using statement is used to allocate an array of qubits for use in a block of code and release those qubits at the end of the block
#line 25 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    var qubits = Allocate.Apply(2L);
#line 27 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 29 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        Set.Apply((initial, qubits[0L]));
#line 30 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        Set.Apply((Result.Zero, qubits[1L]));
                        //X(qubits[0]); //Now we want to manipulate the qubit. First we'll just try to flip it. This is accomplished by performing an X gate before we measure it in , the gate always makes a reverse
#line 33 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
                        // this is for using the hadamard gate				   
#line 34 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        MicrosoftQuantumPrimitiveCNOT.Apply((qubits[0L], qubits[1L]));
#line 36 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        var res = M.Apply<Result>(qubits[0L]);
                        // The let keyword is used to indicate the binding of an immutable variable
                        // Count the number of ones we saw:
#line 39 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                        if ((res == Result.One))
                        {
#line 41 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 44 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
#line 45 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    Set.Apply((Result.Zero, qubits[1L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes);
                    // Return number of times we saw a |0> and number of times we saw a |1>
#line 48 "C:\\Users\\achocoza\\source\\repos\\BELL\\BELL\\Bell.qs"
                    return __result__;
                    // return to variables as a tuple
                    ;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.BELL.BellTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64)>((count, initial));
        }
    }
}