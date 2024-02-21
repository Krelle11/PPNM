using System;

public static class sfuns {

public static double erf(double x){
/// single precision error function (Abramowitz and Stegun, from Wikipedia)
if(x<0) return -erf(-x);
double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
double t=1/(1+0.3275911*x);
double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
return 1-sum*System.Math.Exp(-x*x);
}

public static double gamma(double x){
///single precision gamma function (Gergo Nemes, from Wikipedia)
if(x<0)return Math.PI/Math.Sin(Math.PI*x)/gamma(1-x);
if(x<9)return gamma(x+1)/x;
double lngamma=x*Math.Log(x+1/(12*x-1/x/10))-x+Math.Log(2*Math.PI/x)/2;
return Math.Exp(lngamma);
}

public static double lngamma(double x){
if(x<=0) throw new ArgumentException("lngamma: x<=0");
if(x<9) return lngamma(x+1)-Math.Log(x);
return x*Math.Log(x+1/(12*x-1/x/10))-x+Math.Log(2*Math.PI/x)/2;
}

}//sfuns
