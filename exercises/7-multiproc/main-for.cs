using System.Linq;
class main {

public static int Main(string[] args){
	double sum=0;
	System.Threading.Tasks.Parallel.For( 1, nterms+1, (int i) => sum+=1.0/i );
	System.Console.WriteLine($"Main1: total sum = {sum}");

	long nterms=(long)1e9;
	foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-nterms")nterms=(long)double.Parse(words[1]);
		}
	//System.Console.Write($"Main: nterms={nterms}\n");
	var sum1 = new System.Threading.ThreadLocal<double>(()=>0,trackAllValues:true);
	System.Threading.Tasks.Parallel.For(1,nterms+1,delegate(long i){sum1.Value+=1.0/i;});
	double total = sum1.Values.Sum();
	System.Console.Write($"Main2: total sum = {total}\n");

return 0;
}//Main


}//main
