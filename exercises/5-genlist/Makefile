output.txt: main.exe
	mono main.exe <input.txt 1> output.txt

main.exe: main.cs genlist.dll
	mcs -reference:genlist.dll -target:exe -out:main.exe main.cs

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs

clean:
	rm -f main.exe genlist.dll main.exe output.txt data.txt
