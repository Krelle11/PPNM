using System;
class eps {

	static int Main() {

	Console.Write("hello again\n");
	
	int i = 1;
	while(i+1 > 1) {i++;}
	Console.Write("my max int is {0}\n", i);
	
	if (i == int.MaxValue) {	
		Console.Write("which is equal to int.MaxValue\n");
	}
	
	int j = 1;
	while(j-1 < 1) {j--;}
	Console.Write("my min int is {0}\n", j);
	
	if (j == int.MinValue) {
		Console.Write("which is equal to int.Min.Value\n");
	}	
	
	
	double x=1; while(1+x!=1){x/=2;} x*=2;
	
	Console.Write($"The double precision (double) machine epsilon is {x}\n");
	
	if (x-Math.Pow(2, -52) == 0) {
		Console.Write($"which is about 2^-52\n");
	}

	float y=1f; while((float) 1f+y!=1f){y = y/2f;} y*=2f;	

	Console.Write($"The single precision (float) machine epsilon is {y}\n");	
	
	if (y-Math.Pow(2, -23) == 0) {
                Console.Write($"which is about 2^-32\n");
        }	

	double epsilon = Math.Pow(2, -52);
	double tiny = epsilon/2;	
	double a = 1 + tiny + tiny;
	double b = tiny + tiny + 1;
	Console.Write($"is 'a' equal to 'b'? Answer: {a==b}\n");
	Console.Write($"is 'a' bigger than 1? Answer: {a>1}\n");
	Console.Write($"is 'b' then bigger than 1? Answer: {b>1}\n");
	Console.Write("Since epsilon is an upper bound on the approximation error due to rounding, then 1 + eps/2 = 1 because of rounding, such that 1 + tiny + tiny = 1 + tiny = 1, since arithmetics are done from left to right\n");
	Console.Write("But epsilon isn't the supremum or least upper bound, and so tiny + tiny + 1 = epsilon + 1 != 1\n"); 

	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;
	
	Console.WriteLine($"d1={d1}");
        Console.WriteLine($"d2={d2}");	
	
	Console.WriteLine($"d1={d1:e4}");
        Console.WriteLine($"d2={d2:e4}");	
	
	Console.WriteLine($"d1={d1:e15}");
	Console.WriteLine($"d2={d2:e15}");
	Console.WriteLine($"d1==d2 ? => {d1==d2}");

	Console.WriteLine($"Is 'd1' equal to 'd2' using our approximation function? Answer: {sfuns.approx(d1,d2)}");	
	
	return 0;
	}


	
}
