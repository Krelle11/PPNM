class test2 {

public static int Main() {

string s = System.Console.In.ReadLine();


// writing data (strings) to a file stream

var outfile2 = new System.IO.StreamWriter("outfile2.txt", append:true);  // creating stream connected to the file outfile2.txt
outfile2.WriteLine(s);
outfile2.Close();      // closing the stream


return 0;

}//Main
}//test2
