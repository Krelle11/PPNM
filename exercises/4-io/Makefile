out.txt: main.exe
	echo 1 2 3 4 5 > input.txt
	mono main.exe -numbers:1,2,3,4,5 < input.txt 1> out.txt 2> log.txt

main.exe: main.cs
	mcs main.cs

clean:
	rm -f out.txt main.exe out.txt input.txt
