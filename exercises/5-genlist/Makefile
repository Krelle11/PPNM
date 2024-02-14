Out.txt: main.exe
	mono $<  1> $@

main.exe: main.cs genlist.dll
	mcs -target:exe -reference:genlist.dll -out:main.exe main.cs

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs

clean:
	$(RM) *.dll *.exe log* [Oo]ut*      # removes all that starts with 'O' and then 'ut' or 'o' and then 'ut'
