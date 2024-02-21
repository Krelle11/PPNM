public class main {
public static int Main() {


for (double x = -3; x <= 3; x += 1.0/8) {
double y = sfuns.erf(x);

System.Console.Out.Write(x);
System.Console.Out.Write(" ");
System.Console.Out.WriteLine(y);
}

System.Console.Out.WriteLine(" ");


var outputfile1 = new System.IO.StreamWriter("Out2.txt", append:true);

for (double x = 1; x <= 2; x += 0.01) {
double y = sfuns.gamma(x);

outputfile1.Write(x);
outputfile1.Write(" ");
outputfile1.WriteLine(y);
}

outputfile1.Close();

var outputfile2 = new System.IO.StreamWriter("Out3.txt", append:true);

for (double x = 0.05; x < 4; x+= 0.02) {
double y = sfuns.lngamma(x);

outputfile2.Write(x);
outputfile2.Write(" ");
outputfile2.WriteLine(y);
}

outputfile2.Close();

return 0;

}//Main
}//main
