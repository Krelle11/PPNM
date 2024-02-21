public class genlist<T> {

public T[] data;

public genlist() {
	this.data = new T[0];
}

public int size => data.Length;

public T this[int i] => data[i];	// now e.g. newlist[i] returns data[i]

public void add(T item) {
	T[] newdata = new T[size+1];
	for (int j = 0; j < size; j++) {
		newdata[j] = this.data[j];
	}
	newdata[size] = item;
	this.data = newdata;
}
}
