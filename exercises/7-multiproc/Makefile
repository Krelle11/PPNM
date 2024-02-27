TIME = time --output=out.txt --append --portability --format="$$n %e %U"
MKEXE = mcs -target:exe -out:main.exe main.cs
N = 2e9

out.svg: out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "number of threads";\
		set ylabel "real time";\
		set title "Running time as function of numnber of threads";\
		plot "$<" with lp ;\
		'| tee log.gpi | gnuplot

out.txt: main.exe
	for n in 1 2 3 4 5 6 7 8; do \
	$(TIME) mono main.exe -threads:$$n -terms:$(N); \
	done

main.exe: main.cs
	$(MKEXE)

clean:
	rm -f out.txt main.exe
