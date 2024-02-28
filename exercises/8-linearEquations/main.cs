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
	public double dot(vector v) {
		double dot = 0;
		for (int i = 0; i < size; i++) {
			dot += data[i]*v[i];
		}
		return dot;
	}
	public void scale(double c) {
		for (int i = 0; i < size; i++) {
			data[i] = data[i]*c;
		}
	}
	public static vector operator-(vector u, vector v) {
		vector result = new vector(u.size);
		return result;

		//return new vec(u.x - v.x, u.y - v.y, u.z - v.z);
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
	public double norm(int j) {     // norm of the j'th column
		double len_squared = 0;
		for (int i = 0; i < size1; i++) {
			len_squared += data[i + j*size1]*data[i + j*size1];
		}
		return Math.Sqrt(len_squared);
	}
	public matrix Copy() {
		matrix Q = new matrix(size1, size2);
		for(int i = 0; i < size1; i++) {
			for(int j = 0; j < size2; j++) {
				Q[i, j] = data[i + j*size1];
			}
		}
		return Q;
	}
	public vector get_column(int j) {
		vector columnj = new vector(size1);
		for (int i = 0; i < size1; i++) {
			columnj[i] = data[i + j*size1];
		}
		return columnj;
	}
}


public static class QRGS {
	public static (matrix, matrix) decomp(matrix A) {
		matrix Q = A.Copy();
		matrix R = new matrix(A.size2, A.size2);
		for (int i = 0; i < A.size2; i++) {
			vector Q_column_i = Q.get_column(i);
			R[i, i] = Q_column_i.norm();
			Q_column_i.scale(1/R[i, i]);

			for (int j = i+1; j < A.size2; j++) {
				vector Q_column_j = Q.get_column(j);
				R[i, j] = Q_column_i.dot(Q_column_j);
				//Q_column_j = Q_column_j - Q_column_i.scale(R[i, j]);
			}
		}
		return (Q, R);
	}
}



/*
public static class QRGS {
        public static (matrix, matrix) decomp(matrix A) {      // method to factorize a matrix 'A' into a product of an>                matrix Q = A.Copy();
		matrix Q = A.Copy();
                matrix R = new matrix(A.size2, A.size2);
		for (int i = 0; i < A.size2; i++) {
			R[i, i] = Q.norm(i);
			for (int k = 0; k < Q.size1; k++) {
				Q[i, k] = Q[i, k]/R[i, i];
			}
			for (int s = i + 1; s < A.size2; s++) {
				double Q_i_dot_Q_s = 0;
				for (int l = 0; l < Q.size1; l++)  {
					Q_i_dot_Q_s += Q[i, l]*Q[s, l];
				}
			R[i, s] = Q_i_dot_Q_s;
			}
		}
		return (Q, R);
        }
}
*/

public static class main {

public static int Main() {

var rnd = new System.Random(1);    // for generating random numbers
//System.Console.Out.WriteLine(rnd.NextDouble());



vector vec = new vector(2);

//System.Console.Out.WriteLine($"size of vector is: {vec.size}");

for (int i = 0; i < vec.size; i++) {
	//System.Console.Out.WriteLine($"{i}'th entrance of vector is: {vec[i]}");
	vec[i] = 1;
	//System.Console.Out.WriteLine($"now {i}'th entrance of vector is: {vec[i]}");
	//System.Console.Out.WriteLine($"this means the norm of the vector is: {vec.norm()}");
}


System.Console.Out.WriteLine("time to look at matrices");

matrix matrix1 = new matrix(2, 2);

for (int i = 0; i < matrix1.size1; i++) {
	for (int j = 0; j < matrix1.size2; j++) {
		//System.Console.Out.WriteLine($"({i},{j})'th entrance of matrix is: {matrix1[i, j]}");
		matrix1[i, j] = rnd.NextDouble();
		//System.Console.Out.WriteLine($"now ({i},{j})'th entrance of matrix is: {matrix1[i, j]}");
		//System.Console.Out.WriteLine($"this means the norm of the {j}'th column of the matrix is: {matrix1.norm(j)}");
	}
}


matrix B = matrix1.Copy();


for (int i = 0; i < B.size1; i++) {
        for (int j = 0; j < B.size2; j++) {
                System.Console.Out.WriteLine($"({i},{j})'th entrance of B is: {B[i, j]}");
                //matrix1[i, j] = 1;
                //System.Console.Out.WriteLine($"now ({i},{j})'th entrance of matrix is: {matrix1[i, j]}");
                //System.Console.Out.WriteLine($"this means the norm of the {j}'th column of the matrix is: {matrix1.norm>
	}
}

vector column1 = B.get_column(0);
vector column2 = B.get_column(1);


for (int i = 0; i < column1.size; i++) {
	System.Console.Out.WriteLine($"{i}'th entrance of column 1 is: {column1[i]}");
}

for (int i = 0; i < column2.size; i++) {
        System.Console.Out.WriteLine($"{i}'th entrance of column 2 is: {column2[i]}");
}


System.Console.Out.WriteLine($"dot product between column 1 and column 2 is {column1.dot(column2)}");


column1.scale(10);

for (int i = 0; i < column1.size; i++) {
        System.Console.Out.WriteLine($"after taking scalarproduct with 10 the {i}'th entrance of column 1 is: {column1[i]}");
}





System.Console.Out.WriteLine("doing decomposition of matrix B...");

(matrix Q, matrix R) = QRGS.decomp(B);


for (int i = 0; i < Q.size1; i++) {
        for (int j = 0; j < Q.size2; j++) {
                System.Console.Out.WriteLine($"({i},{j})'th entrance of Q is: {Q[i, j]}");
               }
}

for (int i = 0; i < R.size1; i++) {
        for (int j = 0; j < R.size2; j++) {
                System.Console.Out.WriteLine($"({i},{j})'th entrance of R is: {R[i, j]}");
               }
}




/*
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
