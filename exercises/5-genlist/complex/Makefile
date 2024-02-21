out.txt: main.exe
	mono $< 1> out.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll -target:exe -out:main.exe main.cs

cmath.dll: cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

clean:
	rm -f out.txt cmath.dll main.exe
