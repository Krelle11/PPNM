public class main {
public static int Main() {


var complex_i = new complex(0,1);

//System.Console.Out.WriteLine(complex_i);

var sin_of_i_pi = cmath.sin(complex_i*System.Math.PI);

System.Console.Out.WriteLine($"sin of i times pi is approximately {sin_of_i_pi}");


var complex_minus_one = new complex(-1,0);

//System.Console.Out.WriteLine(complex_minus_one);

var sqrt_of_minus_one = cmath.sqrt(complex_minus_one);

System.Console.Out.WriteLine($"square root of minus one is approximately {sqrt_of_minus_one}");


var sqrt_of_i = cmath.sqrt(complex_i);

System.Console.Out.WriteLine($"square root of i is approximately {sqrt_of_i}");


var e_pow_i = cmath.exp(complex_i);

System.Console.Out.WriteLine($"e to the power of i is approximately {e_pow_i}");


var e_pow_i_pi = cmath.exp(complex_i*System.Math.PI);

System.Console.Out.WriteLine($"e to the power of i times pi is approximately {e_pow_i_pi}");


var i_pow_i = cmath.pow(complex_i, complex_i);

System.Console.Out.WriteLine($"i to the power of i is approximately {i_pow_i}");


var log_of_i = cmath.log(complex_i);

System.Console.Out.WriteLine($"log of i is approximately {log_of_i}");


return 0;
}//Main
}//main
