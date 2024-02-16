using System;

class main {

public static void Main(string[] args) {

foreach(var arg in args) {
	var words = arg.Split(':');
	if(words[0] == "-numbers") {
		var numbers = words[1].Split(',');
		foreach(var number in numbers) {
			double x = double.Parse(number);
			Console.Out.WriteLine($"{x} {Math.Sin(x)} {Math.Cos(x)}");
		}
	}
}

char[] split_delimiters = {' ', '\n', '\t'};

for (string inputstream = Console.In.ReadLine(); inputstream != null; inputstream = Console.In.ReadLine()) {
	var numbers = inputstream.Split(split_delimiters, StringSplitOptions.RemoveEmptyEntries );
	foreach(var number in numbers) {
		double x = double.Parse(number);
		System.Console.Error.WriteLine($"{x} {Math.Sin(x)} {Math.Cos(x)}");
	}

}


}//Main
}//main
