class main{

static int Main(string[] args) {
	
	string infile = null;
	
	string outfile = null;


	foreach(var arg in args) {
		System.Console.Error.WriteLine(arg);             // var means the compiler must figure out the variable type which is string here
		string[] words = arg.Split(':');             // making an array of strings by splitting up each word in args if there is an : present
		if(words[0] == "-input") {                 //
			infile=words[1];
			}

		if(words[0] == "-output") {
                        outfile=words[1];
                        }

		if(words[0] == "-numbers") {
                        string[] numbers = words[1].Split(',');
			foreach(var number in numbers) {
				double x = double.Parse(number);     // better to make x variable outside, so error message doesn't become too long
				System.Console.Error.WriteLine($"{x}");          // then put x inside, instead of write 'foreach...'
				}
                        }
		
		}

		if(infile==null || outfile==null) {
			System.Console.Error.WriteLine("wrong argument");
			return 1;
			}
	
		var instream = new System.IO.StreamReader(infile);
		var outstream = new System.IO.StreamWriter(outfile, append:false);
		

		for(string line = instream.ReadLine(); line!=null; line=instream.ReadLine()) {
				double x = double.Parse(line);
				outstream.WriteLine(x);
			}

		
		instream.Close();
		outstream.Close();

return 0;

}//Main

}//main
