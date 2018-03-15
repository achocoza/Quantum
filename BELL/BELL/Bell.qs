namespace Quantum.BELL
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

     operation Set (desired: Result, q1:Qubit) : ()
    {
        body
        {
            let current = M(q1); // measure

			if (desired != current)
			{
			X(q1);
			}
        }
    }

	 operation BellTest (count : Int, initial: Result) : (Int,Int)
    {
        body
        {
            mutable numOnes = 0; // a mutable variable can change using a set statement
           // using (qubits = Qubit[1]) // the using statement is used to allocate an array of qubits for use in a block of code and release those qubits at the end of the block
            using (qubits = Qubit[2]) // This allow us to add a new gate (CNOT) before we measure (M) in BellTEST
			{
                for (test in 1..count) // use very similar structure like c#
                {
                    Set (initial, qubits[0]);
					 Set (Zero, qubits[1]);
					//X(qubits[0]); //Now we want to manipulate the qubit. First we'll just try to flip it. This is accomplished by performing an X gate before we measure it in , the gate always makes a reverse
                   
				   H(qubits[0]);// this is for using the hadamard gate				   
				    CNOT(qubits[0],qubits[1]);

				   let res = M (qubits[0]);// The let keyword is used to indicate the binding of an immutable variable

                    // Count the number of ones we saw:
                    if (res == One)
                    {
                        set numOnes = numOnes + 1;
                    }
                }
                Set(Zero, qubits[0]);
				Set(Zero, qubits[1]);
            }
            // Return number of times we saw a |0> and number of times we saw a |1>
            return (count-numOnes, numOnes); // return to variables as a tuple
        }
    }



}
	 

