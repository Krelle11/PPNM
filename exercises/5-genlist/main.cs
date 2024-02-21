
public class main {

public static int Main() {

//System.Console.Out.WriteLine("hello");
//System.Console.Error.WriteLine("hello");

/*
genlist<double> mylist = new genlist<double>();

System.Console.Out.WriteLine(mylist.size);
mylist.add(6);
System.Console.Out.WriteLine(mylist.size);
mylist.add(11);
System.Console.Out.WriteLine(mylist.size);

for (int i = 0; i < mylist.size; i++) {
	System.Console.Out.WriteLine(mylist[i]);
}
*/


var outputfile = new System.IO.StreamWriter("data.txt", append:true);

genlist<string> mylines = new genlist<string>();
string line;
int linenr = 1;
//do {System.Console.Out.WriteLine(line);}

while( (line = System.Console.In.ReadLine()) != null) {
	outputfile.WriteLine($"{linenr}. line read is: {line}");
	mylines.add(line);
	linenr += 1;
}

linenr = 1;
for (int i = 0; i < mylines.size; i++) {
	outputfile.WriteLine($"{linenr}. element in mylines is: {mylines[i]}");
	linenr += 1;
}


genlist<double[]> listofnumbers = new genlist<double[]>();

var splitoptions = System.StringSplitOptions.RemoveEmptyEntries;
char[] splitdelimiters = {' ','\t'};

for (int i = 0; i < mylines.size; i++) {
        var words = mylines[i].Split(splitdelimiters, splitoptions);
	var numbers = new double[words.Length];

	for (int j = 0; j < words.Length; j++) {
		outputfile.WriteLine($"{j+1}. element in {i+1}. element of mylines is: {words[j]}");
		numbers[j] = double.Parse(words[j]);
	}

	listofnumbers.add(numbers);
}


for (int i = 0; i < listofnumbers.size; i++) {
	var numbers = listofnumbers[i];
	foreach(var number in numbers) {
		System.Console.Out.WriteLine($"{number : 0.00e+00; -0.00e+00}");
	}
}


outputfile.Close();

return 0;

}//Main
}//main
