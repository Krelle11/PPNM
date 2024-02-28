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
		for (int i = 0; i < result.size; i++) {
			result[i] = u[i] - v[i];
		}
		return result;
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
		vector column_j = new vector(size1);
		for (int i = 0; i < size1; i++) {
			column_j[i] = data[i + j*size1];
		}
		return column_j;
	}
	public void set_column(int j, vector v) {
		for (int i = 0; i < size1; i++) {
			data[i + j*size1] = v[i];
		}
	}
	public vector get_row(int i) {
		vector row_i = new vector(size2);
		for (int j = 0; j < size2; j++) {
			row_i[j] = data[i + j*size1];
		}
		return row_i;
	}
	public void set_row(int i, vector v) {
		for (int j = 0; j < size2; j++) {
			data[i + j*size1] = v[j];
		}
	}
	public matrix matrix_product(matrix B) {
		matrix result = new matrix(size1, B.size2);
		for (int i = 0; i < size1; i++) {
			for (int j = 0; j < B.size2; j++) {
				result[i, j] = get_row(i).dot(B.get_column(j));
			}
		}
		return result;
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


System.Console.Out.WriteLine("lets look at vectors...");

vector vec1 = new vector(2);
vector vec2 = new vector(2);


//System.Console.Out.WriteLine($"size of vector is: {vec.size}");

for (int i = 0; i < vec1.size; i++) {
	System.Console.Out.WriteLine($"{i}'th entrance of vec1 is: {vec1[i]}");
	vec1[i] = rnd.NextDouble();
	System.Console.Out.WriteLine($"now {i}'th entrance of vec1 is: {vec1[i]}");
	//System.Console.Out.WriteLine($"this means the norm of the vector is: {vec1.norm()}");
}

for (int i = 0; i < vec2.size; i++) {
        System.Console.Out.WriteLine($"{i}'th entrance of vec2 is: {vec2[i]}");
        vec2[i] = rnd.NextDouble();
        System.Console.Out.WriteLine($"now {i}'th entrance of vec2 is: {vec2[i]}");
        //System.Console.Out.WriteLine($"this means the norm of the vector is: {vec2.norm()}");
}


vector vec3 = vec1 - vec2;

System.Console.Out.WriteLine($"vec1 minus vec2 we call vec3");

for (int i = 0; i < vec3.size; i++) {
        System.Console.Out.WriteLine($"{i}'th entrance of vec3 is: {vec3[i]}");
}


System.Console.Out.WriteLine("");

System.Console.Out.WriteLine("time to look at matrices...");

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

B.set_column(0, vec3);

for (int i = 0; i < B.size1; i++) {
        for (int j = 0; j < B.size2; j++) {
                System.Console.Out.WriteLine($"after setting the 1'th column of B equal to vec3 the ({i},{j})'th entrance of B is: {B[i, j]}");
	}
}


System.Console.Out.WriteLine("");
System.Console.Out.WriteLine("lets look at columns of a matrix...");

vector column1 = B.get_column(0);
vector column2 = B.get_column(1);

for (int i = 0; i < column1.size; i++) {
	System.Console.Out.WriteLine($"{i}'th entrance of column 1 of B is: {column1[i]}");
}

for (int i = 0; i < column2.size; i++) {
        System.Console.Out.WriteLine($"{i}'th entrance of column 2 of B is: {column2[i]}");
}


System.Console.Out.WriteLine($"dot product between column 1 and column 2 is {column1.dot(column2)}");


column1.scale(10);

for (int i = 0; i < column1.size; i++) {
        System.Console.Out.WriteLine($"after scaling the 1'th column of B with 10 the {i}'th entrance of column 1 is: {column1[i]}");
}


System.Console.Out.WriteLine("");
System.Console.Out.WriteLine("lets look at the rows of a matrix...");

vector row1 = B.get_row(0);
vector row2 = B.get_row(1);

for (int i = 0; i < row1.size; i++) {
        System.Console.Out.WriteLine($"{i}'th entrance of row 1 of B is: {row1[i]}");
}

for (int i = 0; i < row2.size; i++) {
        System.Console.Out.WriteLine($"{i}'th entrance of row 2 of B is: {row2[i]}");
}

B.set_row(0, vec3);

for (int i = 0; i < B.size1; i++) {
        for (int j = 0; j < B.size2; j++) {
                System.Console.Out.WriteLine($"after setting the 1'th row of B equal to vec3 the ({i},{j})'th entrance of B is: {B[i, j]}");
	}
}

System.Console.Out.WriteLine("");

System.Console.Out.WriteLine("lets look at matrix product");

matrix C = new matrix(2, 2);

for (int i = 0; i < C.size1; i++) {
        for (int j = 0; j < C.size2; j++) {
		C[i, j] = rnd.NextDouble();
		System.Console.Out.WriteLine($"the ({i}, {j})'th entrance of C is: {C[i, j]}");
	}
}

matrix G = C.matrix_product(B);

System.Console.Out.WriteLine("we call the product of matrix C with matrix B 'G'");

for (int i = 0; i < G.size1; i++) {
        for (int j = 0; j < G.size2; j++) {
                System.Console.Out.WriteLine($"the ({i}, {j})'th entrance of G is: {G[i, j]}");
        }
}


System.Console.Out.WriteLine("");

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
