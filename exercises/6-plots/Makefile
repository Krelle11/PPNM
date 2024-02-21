CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:, $(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Erf.gnuplot.svg: Out.txt Makefile
	echo '\
		set terminal svg background "white"; \
		set out "$@"; \
		plot [-3:3] \
		"$<" with lines \
		, "erf.data.txt" using 1:2 \
		, "erf.data.txt" using (-($$1)):(-($$2)); \
	' | tee log.gpi | gnuplot
	echo '\
		set terminal svg background "white"; \
		set out "Gamma.gnuplot.svg"; \
		plot [0:3] \
		"Out2.txt" with lines \
		, "gamma.data.txt"; \
	' | tee log.gpi | gnuplot
	echo '\
		set terminal svg background "white"; \
		set out "Lngamma.gnuplot.svg"; \
		plot [0:5] \
		"Out3.txt" with lines; \
	' | tee log.gpi | gnuplot


Out.txt: main.exe
	mono $< > $@

sfuns.dll: sfuns.cs; $(MKLIB)
main.exe: main.cs sfuns.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*


#                ,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
#               ,"erf.data.txt" using (-($$1)):(
