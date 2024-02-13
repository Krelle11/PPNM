default: Out-stdio.txt out.txt test.txt test2.txt

Out-stdio.txt: stdio.exe input
	mono $< <input  1> $@  2>log-stdio.txt              # $< is stdio.exe  so mono $< means to run mono on stdio.exe and 1> $@ means to put the output into Out-stdio.txt
	echo "\n" >> $@
	cat input | mono $< 1>>$@ 2>>log-stdio.txt

	
	# 2> log-stdio.txt means to put the error into log-stdio.txt

cmdline.exe: cmdline.cs
	mcs -target:exe -out:$@ $<                            # here $@ is cmdline.exe     and $< is cmdline.cs

stdio.exe: stdio.cs
	mcs -target:exe -out:$@ $<

out.txt: cmdline.exe input.txt
	mono cmdline.exe -input:input.txt -output:$@ -numbers:2,3.45,6                   # here -input is input.txt while -output is $@ and lastly -numbers are

test.txt: test.exe
	mono test.exe 1> test.txt 2> testerror.txt

test.exe: test.cs
	mcs -target:exe -out:$@ $<

test2.exe: test2.cs
	mcs -target:exe -out:$@ $<

test2.txt: test2.exe
	mono test2.exe < input                    # The standard input stream of a program can be disattached from the console and attached to a "file" with the directive "<file". For example the shell command to the left attaches the standard input stream of the program test2.exe to the file input such that all reads from the standard input actually read from the attached file.
	echo 445112 | mono test2.exe           # The pipe, |, connects the standard output of one program to the standard input of another program so the line to the left sends the string "445112" into the standard input of the program test2.exe
	cat input.txt | mono test2.exe               # sends the file input.txt into the standard input of the program test2.exe;

clean:
	rm -f test.txt test.exe out.txt stdio.exe cmdline.exe Out-stdio.txt log-stdio.txt outfile.txt outfile2.txt test2.exe
