public class main {


public class data {

// instance variables
public int a;
public int b;
public double sum_ab;

}//data


public static void harmonic_sum(object obj) {

data x = (data)obj;      // casting type of obj to 'data'
x.sum_ab = 0;       // this means now we can acces the instance variable 'sum_ab'

System.Console.WriteLine($"summing 1/n from n = {x.a} to n = {x.b}");


for (int i = x.a; i <= x.b; i++) {

	System.Console.Out.WriteLine($"right now x.sum_ab is: {x.sum_ab}");
	x.sum_ab += (double)1/i;
	System.Console.Out.WriteLine($"plus 1/{i} it becomes: {x.sum_ab}");
	}

}//harmonic_sum



public static int Main() {

data test = new data();
test.a = 1;
test.b = 3;
test.sum_ab = 10;
System.Console.Out.WriteLine($"right now test.sum_ab is: {test.sum_ab}, test.a is: {test.a} and test.b is: {test.b}");

harmonic_sum(test);
System.Console.Out.WriteLine($"after running harmonic_sum, test.sum_ab gives: {test.sum_ab}");
// System.Console.Out.WriteLine($"and x.sum_ab gives: {x.sum_ab}");



return 0;

}//Main


}//main
