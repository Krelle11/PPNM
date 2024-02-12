Out.txt : main.exe eps.exe
	mono $< <eps.exe > $@                # <eps.exe is what
	mono eps.exe >> $@

eps.exe : eps.cs sfuns.dll
	mcs -reference:sfuns.dll eps.cs

vec.dll : vec.cs
	mcs -target:library vec.cs

sfuns.dll : sfuns.cs
	mcs -target:library sfuns.cs

main.exe : main.cs vec.dll
	mcs -reference:vec.dll main.cs

clean:
	rm -f Out.txt main.exe vec.exe eps.exe sfuns.dll
