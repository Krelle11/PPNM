class test {

public static int Main() {


// writing to data (strings) the output stream

System.Console.Out.Write("hello this is a test to see whether the standard output stream is connected to the console(terminal)\n");
System.Console.Out.WriteLine("because then what I write to the standard output stream (e.g. this text) is sent to the console");

System.Console.WriteLine("another test\n");
//System.IO.TextWriter("test again\n");

var stdout = System.Console.Out;

stdout.WriteLine("Console.Out is a TextWriter (in the System namespace) which is an abstract class in C# that provides methods for writing to text data to a stream\n");


// writing data (strings) to the error stream

System.Console.Error.WriteLine("testing to see whether the standard error stream is connected to the console (terminal)");

var stderr = System.Console.Error;

stderr.WriteLine("because then what I write to the standard error stream will be sent to the console (as data i.e a string)");


// writing data (strings) to a file stream

var outfile = new System.IO.StreamWriter("outfile.txt", append:true);  // creating stream connected to the file outfile.txt
outfile.WriteLine("testing to see whether the data (string) is written to the specified file");
outfile.WriteLine(double.Parse("50"));
outfile.Close();      // closing the stream


// standard input stream

System.Console.Out.WriteLine("Every (console) C#-program has the standard input stream, 'System.Console.In', automatically opened and connected to the keyboard of the terminal (console) from which the program is run (but can be conveniently redirected)");

string s = System.Console.In.ReadLine();

System.Console.Out.WriteLine(s);




return 0;

}//Main
}//test
