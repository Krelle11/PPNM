using System;

public class my_class  {public string s;}
public struct my_struct {public string s;}

class main {

static int Main() {
	double x=2, y=1;
	if (x>y) {Console.Write($"{x} is bigger than {y}\n"); }
	else {Console.Write("nope"); }
	
	for (int i = 1; i < 10; i++) {
		Console.Write("hello\n");
	}
	
	double[] row = new double[5]{1,2,3,4,5};
	for (int i = 0; i < 5; i++) {
		Console.Write($"{row[i]}\n");
	}
	
	my_class A = new my_class();
	my_struct a = new my_struct();
	A.s = "hello";
	a.s = "hello";
	Console.WriteLine($"A.s={A.s}");
	Console.WriteLine($"a.s={a.s}");
	my_class B = A;
	my_struct b = a;

	Console.WriteLine($"B.s={B.s}");
        Console.WriteLine($"b.s={b.s}");
	
	B.s = "new hello";
	b.s = "new hello";

	Console.WriteLine($"A.s={A.s}");
        Console.WriteLine($"a.s={a.s}");


	double[] vector = new double[5];
	for (int j = 0; j < 5; j++) {
		Console.WriteLine($"vector[{j}] is equal to {vector[j]}\n");
	}

	Console.WriteLine("Time to play with euclidean vectors");
	vec zeroVector = new vec();	
	
	Console.Write($"The first entrance of our zero vector is in fact {zeroVector.x}\n");
	Console.Write($"The second entrance of our zero vector is in fact {zeroVector.y}\n");
	Console.Write($"The third entrance of our zero vector is in fact {zeroVector.z}\n");
	
	vec Vector1 = new vec(2, 2, 3);

	Console.Write($"The first entrance of our first non-zero vector is in fact {Vector1.x}\n");
        Console.Write($"The second entrance of our first non-zero vector is in fact {Vector1.y}\n");
        Console.Write($"The third entrance of our first non-zero vector is in fact {Vector1.z}\n");
	
	vec Vector2 = new vec(3, 6, 5);

	Console.Write($"The first entrance of our second non-zero vector is in fact {Vector2.x}\n");
        Console.Write($"The second entrance of our second non-zero vector is in fact {Vector2.y}\n");
        Console.Write($"The third entrance of our second non-zero vector is in fact {Vector2.z}\n");

	double c = 2;	

	Console.Write($"Our constant 'c' will be {c}\n");

	vec Vector3 = c*Vector1;
	vec Vector4 = Vector1*c;
			
	Vector1.print("Vector1 has the entrances: ");
	Vector3.print("2 times Vector1 has the entrances: ");
	Vector4.print("Vector1 times 2 has the entrances: ");

	vec Vector5 = Vector3 + Vector4;
	vec Vector6 = Vector3 - Vector4;
	vec Vector7 = -Vector3;
	
	Vector5.print("2 times Vector1 plus Vector1 times 2 has the entrances: "); 
	Vector6.print("2 times Vector1 minus Vector1 times 2 has the entrances: ");
	Vector7.print("Minus 2 times Vector1 has the entrances: ");

	Vector1.print("Vector1 has the entrances: ");
        Vector3.print("2 times Vector1 has the entrances: ");

	double dot1 = Vector1.dot(Vector3);
	Console.WriteLine($"Vector1 dotted with 2 times Vector1 is: {dot1}");

	return 0;
}//Main
}//main
