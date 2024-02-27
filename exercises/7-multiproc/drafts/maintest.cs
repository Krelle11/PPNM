using System.Threading;

public class main {

public class data {

// instance variables
public int a;
public int b;
public double sum_ab;

}//data


public static void harmonic_sum(object obj) {

data x = (data)obj;      // casting type of obj to 'data'
x.sum_ab = 0;       // this means now we can acces the instance variable 'sum_ab'

//System.Console.WriteLine($"summing 1/n from n = {x.a} to n = {x.b}");

//System.Console.Out.WriteLine($"right now x.sum_ab is: {x.sum_ab}");

for (int i = x.a; i < x.b; i++) {
	x.sum_ab += (double)1/i;
	//System.Console.Out.WriteLine($"plus 1/{i} it becomes: {x.sum_ab}");
	}

//System.Console.Out.WriteLine($"after summing x.sum_ab is: {x.sum_ab}");

}//harmonic_sum



public static int Main(string[] args) {


int no_of_threads = 1;
int no_of_terms = (int)1e8;

foreach (string arg in args) {
	//System.Console.Out.WriteLine(arg);
	var words = arg.Split(':');
	if (words[0] == "-threads") {
		//System.Console.Out.WriteLine($"number of threads to be used is {words[1]}");
		no_of_threads = int.Parse(words[1]);
	} else if (words[0] == "-terms") {
		//System.Console.Out.WriteLine($"number of terms in harmonic sum is {words[1]}");
		no_of_terms = (int)float.Parse(words[1]);
		//System.Console.Out.WriteLine($"i.e the number of terms is {no_of_terms}");
	}
}


/*
data test = new data();
test.a = 1;
test.b = 1001;
test.sum_ab = 10;
System.Console.Out.WriteLine($"right now test.sum_ab is: {test.sum_ab}, test.a is: {test.a} and test.b is: {test.b}");
*/

//System.Console.Out.WriteLine(no_of_terms);

//System.Console.Out.WriteLine(no_of_threads);

int terms_pr_thread = no_of_terms/no_of_threads;

//System.Console.Out.WriteLine(terms_pr_thread);


data[] parameters = new data[no_of_threads];
for (int i = 0; i < no_of_threads; i++) {
	parameters[i] = new data();
	parameters[i].a = 1 + terms_pr_thread * i;
	parameters[i].b = 1 + terms_pr_thread * (i + 1);
}

//System.Console.Out.WriteLine($"right now the last term is: {parameters[parameters.Length - 1].b} so we'll manually set it to {no_of_terms + 1}");

parameters[parameters.Length - 1].b = no_of_terms + 1;

foreach (data parameter in parameters) {
	//System.Console.Out.WriteLine(parameter.a);
	//System.Console.Out.WriteLine(parameter.b);
}


/*

double harmonic_sum = 0;

for (int i = 0; i < no_of_threads; i++) {

Thread t = new Thread(harmonic_sum);

t.Start(parameters[i]);

t.Join();

*/

//harmonic_sum += parameters[i].sum_ab;


var threads = new Thread[no_of_threads];
for(int i = 0; i < no_of_threads; i++) {
	threads[i] = new Thread(harmonic_sum);
	threads[i].Start(parameters[i]);
}

foreach(Thread thread in threads) {
	thread.Join();
}


double sum = 0;

foreach(data parameter in parameters) {
	sum += parameter.sum_ab;
}


System.Console.Out.WriteLine(sum);



/*

var threads = new System.Threading.Thread[no_of_threads];
for(int i=0; i < no_of_threads; i++) {
   threads[i] = new System.Threading.Thread(harmonic_sum);
   threads[i].Start(parameters[i]);
   }

*/



/*

Thread t = new Thread(harmonic_sum);    // creating instance of Thread class with the function 'harmonic_sum' as input for contructor

t.Start(test);     // using the Start method of the Thread object

t.Join();   // using the Join method of the Thread object to block the thread calling the method (i.e. the master thread) until the thread whose method is being called has finished running

*/


//harmonic_sum(test);
//System.Console.Out.WriteLine($"after running harmonic_sum, test.sum_ab gives: {test.sum_ab}");
// System.Console.Out.WriteLine($"and x.sum_ab gives: {x.sum_ab}");


return 0;

}//Main


}//main
