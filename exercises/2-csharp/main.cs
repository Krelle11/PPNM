using System;
class calc {

	static void Main() {
	double sqrt2 = Math.Sqrt(2.0);
	double pow1 = Math.Pow(2.0, 1.0/5.0);
	double pow2 = Math.Exp(Math.PI);
	double pow3 = Math.Pow(Math.PI, Math.E);
	Console.Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
	Console.Write($"pow1 to the power of 5 = {Math.Pow(pow1, 5)} (should equal 2)\n");
	Console.Write($"ln(pow2) = {Math.Log(pow2)} (should equal pi)\n");
	Console.Write($"the eth root of pow3 = {Math.Pow(pow3, 1/Math.E)} (should equal pi)\n");	
	
	for (int i = 0; i < 11; i++) {
		double[] results = {1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880}; 
		double x = sfuns.fgamma(i+1);
		Console.Write($"lnfgamma{(i)} is equal to {x}\n");
		Console.Write($"and fgamma{(i)} minus {results[i]} is {x - results[i]}\n");
		}
	}	
	
}
