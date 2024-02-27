using System;

public class vector {
	public double[] data;      // vector elements
	public int size => data.Length;
	public double this[int i] {
		get => data[i];
		set => data[i] = value;
	}
	public vector(int n) {
		data = new double[n];
	}
	public double norm() {
		double len_squared = 0;
		for (int i = 0; i < size; i++) {
			len_squared += data[i]*data[i];
		}
		return Math.Sqrt(len_squared);
	}
}

public class matrix {
	public readonly int size1, size2;
	private double[] data;       // matrix elements
	public matrix(int n, int m) {
		size1 = n;
		size2 = m;
		data = new double[size1*size2];
	}
	public double this[int i, int j] {
		get => data[i + j*size1];
		set => data[i + j*size1] = value;
		}
	public double norm(int j) {
		double len_squared = 0;
		for (int i = 0; i < size1; i++) {
			len_squared += data[i + j*size1]*data[i + j*size1];
		}
		return Math.Sqrt(len_squared);
	}
}


public static class main {

public static int Main() {

var rnd = new System.Random(1);    // for generating random numbers
//System.Console.Out.WriteLine(rnd.NextDouble());



vector vec = new vector(2);

System.Console.Out.WriteLine($"size of vector is: {vec.size}");

for (int i = 0; i < vec.size; i++) {
	System.Console.Out.WriteLine($"{i}'th entrance of vector is: {vec[i]}");
	vec[i] = 1;
	System.Console.Out.WriteLine($"now {i}'th entrance of vector is: {vec[i]}");
	System.Console.Out.WriteLine($"this means the norm of the vector is: {vec.norm()}");
}


System.Console.Out.WriteLine("time to look at a matrix");

matrix matrix1 = new matrix(2, 2);

for (int i = 0; i < matrix1.size1; i++) {
	for (int j = 0; j < matrix1.size2; j++) {
		System.Console.Out.WriteLine($"({i},{j})'th entrance of matrix is: {matrix1[i, j]}");
		matrix1[i, j] = 1;
		System.Console.Out.WriteLine($"now ({i},{j})'th entrance of matrix is: {matrix1[i, j]}");
		System.Console.Out.WriteLine($"this means the norm of the {j}'th column of the matrix is: {matrix1.norm(j)}");
	}
}







/*

public static class QRGS {
	public static (matrix, matrix) decomp(matrix A) {      // method to factorize a matrix 'A' into a product of an orthogonal matrix 'Q' and a triangular matrix 'R'
		matrix Q = A.Copy();
		matrix R = new matrix(A.size2, A.size2);

		//matrix Q=A. copy () , R=new matrix (m,m) ;
		for (int i = 0; i < m; i++){
		R[i, i] = Q[i] . norm ( ) ; /∗ Q[ i ] points to the i−th columb ∗/
		Q[ i ]/=R[ i , i ] ;
		for ( int j=i +1;j<m; j++){
		R[ i , j ]=Q[ i ] . dot (Q[ j ] ) ;
		Q[ j]−=Q[ i ]∗R[ i , j ] ; } }


		return (Q, R);
	}
	public static vector solve(matrix Q, matrix R, vector b) {
		return b;
	}
	public static double det(matrix R) {
		return 0;
	}
}

*/


return 0;
}//Main
}//main
