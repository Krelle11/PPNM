output.txt: main.exe
	mono main.exe -input:input.txt -output:output.txt

main.exe: main.cs
	mcs main.cs

clean:
	rm -f main.exe output.txt
