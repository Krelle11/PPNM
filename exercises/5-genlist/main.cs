class main {


/*

public static System.Func<double, double> make_power(int i) {
	double a = 4;
	System.Func<double, double> f = delegate(double x){return System.Math.Pow(x*a, i);};
	return f;
}

*/


public static int Main() {

genlist<double> newlist = new genlist<double>();

//System.Console.Out.WriteLine($"size={newlist.size()} length={newlist.data.Length}");

newlist.add(2);
//System.Console.Out.WriteLine($"size={newlist.size()} length={newlist.data.Length}");

newlist.add(3);
//System.Console.Out.WriteLine($"size={newlist.size()} length={newlist.data.Length}");

newlist.add(5);

for (int i = 0; i < newlist.size(); i++) {
	System.Console.Out.WriteLine(newlist[i]);
}

/*

double x = 10;
double a = 7;
System.Func<double, double> f = delegate(double tmp) {return a;};

System.Console.WriteLine($"f({x}) = {f(x)}");


var flist = new genlist<System.Func<double, double>>();

flist.add(f);

flist.add(System.Math.Sin);

System.Console.WriteLine(flist.size());

for(int i = 0; i < flist.size(); i++) {
	System.Console.Out.WriteLine($"f[{i}]({x}) = {flist[i](x)}");
}

*/

return 0;

}//Main
}//main
