using System;

public class vector {
	public double[] data;      // vector elements
	public int size => data.Length;
	public double this[int i] {
		get => data[i];
		set => data[i] = value;
	}
	public vector(int n) {         // constructor
		data = new double[n];
	}
	public vector(int n, int a) {     // constructor for vector with random entries between 0 and a
		data = new double[n];
		var rnd = new System.Random(a);
		for (int i = 0; i < this.size; i++) {
			data[i] = rnd.NextDouble();
		}
	}
	public double norm() {
		double len_squared = 0;
		for (int i = 0; i < size; i++) {
			len_squared += data[i]*data[i];
		}
		return Math.Sqrt(len_squared);
	}
	public double dot(vector v) {
		if (this.size != v.size) {
			throw new InvalidOperationException("vectors must be the same size!");
		}
		double dot = 0;
		for (int i = 0; i < size; i++) {
			dot += data[i]*v[i];
		}
		return dot;
	}
	public vector scale(double c) {
		vector result = new vector(size);
		for (int i = 0; i < size; i++) {
			result[i] = this.data[i]*c;
		}
		return result;
	}
	public static vector operator-(vector u, vector v) {
		if (u.size != v.size) {
			throw new InvalidOperationException("vectors must be the same size!");
		}
		vector result = new vector(u.size);
		for (int i = 0; i < result.size; i++) {
			result[i] = u[i] - v[i];
		}
		return result;
	}

	static bool approx(double a, double b, double acc=1e-9, double eps=1e-9) {
		if(Math.Abs(a-b) < acc) {
			return true;
		}
		if(Math.Abs(a-b)/(Math.Abs(a) + Math.Abs(b)) < eps) {
			return true;
		}
		return false;
	}
	public bool approx(vector v) {
		if(this.size != v.size) {
			throw new InvalidOperationException("vectors must be the same size!");
		}
		for (int i = 0; i < this.size; i++) {
			if(!approx(data[i], v[i])) {
				return false;
			}
		}
		return true;
	}
	public void print(string s) {
		System.Console.Out.Write(s);
		System.Console.Out.WriteLine("");
		for (int i = 0; i < this.size; i++) {
			System.Console.Out.WriteLine(data[i]);
		}
	}

}


public class matrix {
	public readonly int size1, size2;
	private double[] data;       // matrix elements
	public matrix(int n, int m) {     // constructor
		size1 = n;
		size2 = m;
		data = new double[size1*size2];
	}
	public matrix(int n, int m, int a) {    // constructor for matrix with random entries between 0 and a
		size1 = n;
		size2 = m;
		var rnd = new System.Random(a);
		data = new double[size1*size2];
		for(int i = 0; i < size1; i++) {
                        for(int j = 0; j < size2; j++) {
                                data[i + j*size1] = rnd.NextDouble();
                        }
		}
	}
	public matrix(int n) {        // constructor for identity matrix of dimension n
		size1 = n;
		size2 = n;
		data = new double[n*n];
		for (int i = 0; i < n; i++) {
			data[i + i*size1] = 1;
		}
	}
	public double this[int i, int j] {
		get => data[i + j*size1];
		set => data[i + j*size1] = value;
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
		if (size1 != v.size) {
			throw new InvalidOperationException("column vector and input vector must be the same size!");
		}
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
		if (size2 != v.size) {
			throw new InvalidOperationException("vectors must be the same size!");
		}
		for (int j = 0; j < size2; j++) {
			data[i + j*size1] = v[j];
		}
	}
	public matrix matrix_product(matrix B) {
		if (this.size2 != B.size1) {
			throw new InvalidOperationException("The number of columns in this matrix must match the number of rows in matrix B!");
		}
		matrix result = new matrix(size1, B.size2);
		for (int i = 0; i < size1; i++) {
			for (int j = 0; j < B.size2; j++) {
				result[i, j] = get_row(i).dot(B.get_column(j));
			}
		}
		return result;
	}
	public void print(string s) {
		System.Console.Out.Write(s);
		for (int i = 0; i < this.size1; i++) {
			System.Console.Out.WriteLine("");
			for (int j = 0; j < this.size2; j++) {
				System.Console.Out.Write($"{data[i + j*size1]}   ");
			}
		}
	System.Console.Out.WriteLine("");
	}
	static bool approx(double a, double b, double acc=1e-9, double eps=1e-9) {
		if(Math.Abs(a-b) < acc) {
                        return true;
                }
                if(Math.Abs(a-b)/(Math.Abs(a) + Math.Abs(b)) < eps) {
                        return true;
                }
                return false;
        }
	public bool approx(matrix m) {
		if(this.size1 != m.size1 || this.size2 != m.size2) {
			throw new InvalidOperationException("The matrices must be the same size!");
		}
		for (int i = 0; i < this.size1; i++) {
                        for (int j = 0; j < this.size2; j++) {
				if(!approx(data[i + j*size1], m[i, j])) {
					return false;
				}
                        }
		}
		return true;
	}
	public matrix transpose() {
		matrix result = new matrix(size2, size1);
		for (int j = 0; j < this.size2; j++) {
			result.set_row(j, get_column(j));
		}
		return result;
	}
	public vector vector_multiplication(vector v) {
		if (this.size2 != v.size) {
			throw new InvalidOperationException("vector doesn't have the right size!");
		}
		matrix m = new matrix(v.size, 1);
		m.set_column(0, v);
		vector result = matrix_product(m).get_column(0);
		return result;
	}
}


public static class QRGS {          // QR-decomposition by modified Gram-Schmidt orthogonalization
	public static (matrix, matrix) decomp(matrix A) {
		if (A.size1 < A.size2) {
			throw new InvalidOperationException("A must be either square or a tall matrix!");
		}
		matrix Q = A.Copy();
		matrix R = new matrix(A.size2, A.size2);
		for (int i = 0; i < A.size2; i++) {
			vector Q_column_i = Q.get_column(i);
			R[i, i] = Q_column_i.norm();
			Q_column_i = Q_column_i.scale(1/R[i, i]);
			Q.set_column(i, Q_column_i);

			for (int j = i+1; j < A.size2; j++) {
				vector Q_column_j = Q.get_column(j);
				R[i, j] = Q_column_i.dot(Q_column_j);
				Q_column_j = Q_column_j - Q_column_i.scale(R[i, j]);
				Q.set_column(j, Q_column_j);
			}
		}
		return (Q, R);
	}
	public static void backsub(matrix R, vector c) {
		if (R.size1 != c.size) {
			throw new InvalidOperationException("vector doesn't have the right size!");
		}
		for (int i = c.size - 1; i >= 0; i--) {
			double sum = 0;
			for (int k = i + 1; k < c.size; k++) {
				sum += R[i, k]*c[k];
				c[i] = (c[i] - sum)/R[i, i];
			}
		}
	}
	public static vector solve(matrix A, vector b) {
		if (A.size1 != b.size) {
			throw new InvalidOperationException("vector doesn't have the right size!");
		}
		(matrix Q, matrix R) = decomp(A);
		vector c = Q.transpose().vector_multiplication(b);
		backsub(R, c);
		return c;
	}
	public static double det(matrix A) {
		if (A.size1 != A.size2) {
			throw new InvalidOperationException("matrix must be square!");
		}
		(matrix R, matrix Q) = decomp(A);
		double result = R[0, 0];
		for (int i = 1; i < R.size1; i++) {
			result *= R[i, i];
		}
		return result;
	}
}



public static class main {

public static int Main() {

/*
matrix A = new matrix(15, 7, 1);
A.print("matrix A");
(matrix Q, matrix R) = QRGS.decomp(A);
Q.print("matrix Q");
Q.transpose().print("transpose of Q");
matrix Q_transpose_times_Q = Q.transpose().matrix_product(Q);
Q_transpose_times_Q.print("Q transpose times Q");
matrix I = new matrix(7);
I.print("identity matrix of dimension 7");
System.Console.Out.WriteLine($"is the product of Q transpose with Q equal (within precision) to I? Answer: {Q_transpose_times_Q.approx(I)}");
R.print("matrix R");
matrix M = Q.matrix_product(R);
System.Console.Out.WriteLine($"is the product of Q with R equal (within precision) to A? Answer: {M.approx(A)}");
*/

/*
matrix G = new matrix(4, 3, 1);
G.print("matrix G");
vector w = new vector(3, 1);
w.print("vector w");
vector u = G.vector_multiplication(w);
u.print("G times v gives:");
*/

matrix H = new matrix(2, 2, 1);
H.print("matrix H");
vector b = new vector(2, 1);
b.print("vector b");
vector x = QRGS.solve(H, b);
x.print("vector x");

System.Console.Out.WriteLine($"is H times x equal to b? Answer: {H.vector_multiplication(x).approx(b)}");

System.Console.Out.WriteLine($"determinant of H is: {QRGS.det(H)}");

return 0;
}//Main
}//main
