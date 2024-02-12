default: Out-stdio.txt out.txt

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
