class main {

public static int Main(string[] args) {

var my_streamreader = new System.IO.StreamReader("input.txt");
string t = my_streamreader.ReadLine();
System.Console.Out.WriteLine(t);
my_streamreader.Close();

//string s = System.Console.In.ReadLine();


//System.Console.Out.WriteLine(s);


if (args.Length == 0) {

	System.Console.WriteLine("no argument was given");
	return 1;

} else {

	string test = args[0];

	System.Console.Out.WriteLine(test);


	var words = test.Split(':');

	System.Console.Out.WriteLine(words.Length);

	foreach (var word in words) {
		System.Console.Out.WriteLine(word);
	}

	//string test2 = args[1];

	//System.Console.Out.WriteLine(test2);

	return 0;
}





//System.Console.Error.Write("This errormessage goes to the log\n");

//System.Console.Error.WriteLine("what about this errormessage");

//System.Console.Out.Write("This message goes to the output stream\n");

}//Main
}//main
