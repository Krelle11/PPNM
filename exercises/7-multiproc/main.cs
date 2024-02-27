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

for (int i = x.a; i < x.b; i++) {
	x.sum_ab += (double)1/i;
	}

}//harmonic_sum


public static int Main(string[] args) {

int no_of_threads = 1;
int no_of_terms = (int)1e8;

foreach (string arg in args) {
	var words = arg.Split(':');
	if (words[0] == "-threads") {
		no_of_threads = int.Parse(words[1]);
	} else if (words[0] == "-terms") {
		no_of_terms = (int)float.Parse(words[1]);
	}
}


int terms_pr_thread = no_of_terms/no_of_threads;

data[] parameters = new data[no_of_threads];
for (int i = 0; i < no_of_threads; i++) {
	parameters[i] = new data();
	parameters[i].a = 1 + terms_pr_thread * i;
	parameters[i].b = 1 + terms_pr_thread * (i + 1);
}

parameters[parameters.Length - 1].b = no_of_terms + 1;


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


return 0;

}//Main
}//main
