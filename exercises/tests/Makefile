main.txt: main.exe
	mono main.exe 1> main.txt 2> log.txt

main.exe: main.cs
	mcs main.cs

clean:
	rm -f *.exe *[Oo]ut.txt main.txt log.txt
