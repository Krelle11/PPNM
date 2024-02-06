Out.txt : main.exe
	mono main.exe > Out.txt

sfuns.dll : sfuns.cs
	mcs -target:library sfuns.cs

main.exe : main.cs sfuns.dll
	mcs -reference:sfuns.dll main.cs

clean:
	rm -f Out.txt main.exe
