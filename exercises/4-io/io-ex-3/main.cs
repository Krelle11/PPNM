class main {

public static int Main(string[] args) {


string inputfile = null, outputfile = null;

foreach(var arg in args) {

	System.Console.Out.WriteLine(arg);
	var words = arg.Split(":");


	if (words[0] == "-input") {
		inputfile = words[1];
	} else if (words[0] == "-output") {
		outputfile = words[1];
	}

}

if (inputfile == null || outputfile == null) {
	System.Console.Error.Write("the command-line argument for 'main.exe' was incorrect\n");
	return 1;
}


var instream = new System.IO.StreamReader(inputfile);
var outstream = new System.IO.StreamWriter(outputfile);

string line = instream.ReadLine();
int linenr = 1;


do {

	System.Console.Out.WriteLine($"{linenr}. line read from 'input.txt' is: {line}");

	linenr += 1;
	line.Replace(",", "");

	double x = double.Parse(line);
	outstream.WriteLine($"{x} {System.Math.Sin(x)} {System.Math.Cos(x)}");
	line = instream.ReadLine();

} while (line != null);


instream.Close();
outstream.Close();


/*
string s = instream.ReadLine();
string t = instream.ReadLine();
string v = instream.ReadLine();

System.Console.Out.WriteLine(s);
System.Console.Out.WriteLine(t);
System.Console.Out.WriteLine(v);
*/


return 0;

}//Main
}//main
