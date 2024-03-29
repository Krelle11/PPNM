using System;

public class vec {

public double x, y, z; // instance variables


// constructors

public vec() {x=0; y=0; z=0;}
public vec(double x, double y, double z) {
	this.x = x;
	this.y = y;
	this.z = z;
}

// getter-methods to return the entrances of a vector, in case the instance variables are made private

public double getFirstEntrance() {return this.x;}
public double getSecondEntrance() {return this.y;}
public double getThirdEntrance() {return this.z;}


// overload methods

public static vec operator*(vec v, double c) {
	return new vec(c*v.x, c*v.y, c*v.z);
}

public static vec operator*(double c, vec v) {
	return new vec(v.x*c, v.y*c, v.z*c);
}

public static vec operator+(vec u, vec v) {
	return new vec(u.x + v.x, u.y + v.y, u.z + v.z);
}

public static vec operator-(vec v) {
	return new vec(-v.x, -v.y, -v.z);
}

public static vec operator-(vec u, vec v) {
	return new vec(u.x - v.x, u.y - v.y, u.z - v.z);
}

// print methods for testing/debugging

public void print(string s) {
	Console.Write(s );
	Console.WriteLine($"{this.x} {this.y} {this.z}");
}

public void print() {
	print("");
}

// dot product methods

public double dot(vec other) /* to be called as u.dot(v) */
	{return this.x*other.x+this.y*other.y+this.z*other.z;}

public static double dot(vec v,vec w) /* to be called as vec.dot(u,v) */
	{return v.x*w.x+v.y*w.y+v.z*w.z;}


// approximation method

static bool approx(double a, double b, double acc=1e-9, double eps=1e-9) {
	if(Math.Abs(a-b) < acc) {
		return true;
	}
	if(Math.Abs(a-b)/(Math.Abs(a) + Math.Abs(b)) < eps) {
		return true;
	}
	return false;
}

public bool approx(vec other) {
	if(!approx(this.x,other.x)){return false;}
        if(!approx(this.y,other.y)){return false;}
        if(!approx(this.z,other.z)){return false;}
        return true;

}

public static bool approx(vec u, vec v) {
	return u.approx(v);
}

public override string ToString() {
	return this.x.ToString() + ", " + this.y.ToString() + ", " + this.z.ToString();
}



}
