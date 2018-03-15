using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.BELL
{
    class Driver
    {
        

        static void Main(string[] args)
        {
            using (var sim = new QuantumSimulator()) // sim is the simulator
            {
                
                // Try initial values
                Result[] initials = new Result[] { Result.Zero, Result.One };
                foreach (Result initial in initials)//Compute any arguments required for the quantum algorithm. 
                {


                    var res = BellTest.Run(sim, 1000, initial).Result;//In the example, count is fixed at a 1000 and initial is the initial value of the qubit.
                                                                      var (numZeros, numOnes) = res;
                    // var (numZeros, numOnes, agree) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");
                    //System.Console.WriteLine(
                    // $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");
                }
            }
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}