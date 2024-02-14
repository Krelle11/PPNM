public class genlist<T> {

// instance variables

public T[] data;


// constructor

public genlist() {
	data = new T[0];
}


// methods

public int size() {
	return data.Length;
}

public void add(T item) {
	System.Console.WriteLine($"Call of 'add' method for genlist object");
	System.Console.WriteLine($"Right now nothing has been done, so the the 'size' of the array 'data' as given by size() is: {size()} and more directly its length is: {data.Length}");
	T[] newdata = new T[this.size()+1];
	System.Console.WriteLine($"Now the temporary array 'newdata' has been created. The method call 'size()' still returns the size of the 'data' array which is {size()}");
	System.Console.WriteLine($"But the length of the array 'newdata' should be {size()} + 1, and it is in fact: {newdata.Length}");
	for (int i = 0; i < data.Length; i ++) {
		newdata[i] = data[i];
	}

	newdata[data.Length] = item;

	System.Console.WriteLine($"We are now at the end of the for-loop. All data has been copied from 'data' to 'newdata', and the input parameter 'item' (of type T) from the method header has been placed at the end");
	System.Console.WriteLine($"The size of 'newdata' thus is: {newdata.Length}");
	data = newdata;

	System.Console.WriteLine($"Now we have set the array 'data' equal to 'newdata' and so the size of 'data' as given by the method call 'size()' is: {size()} and more directly the length of the array 'data' is: {data.Length}");
	System.Console.WriteLine($"Also the last object in 'data' is now {data[this.size() - 1]} which is equal to the input parameter i.e to: {item}");
	}



public T this[int i] => data[i];


// making main function inside this class but doesn't seem to work

/*

public static int Main() {
	genlist testlist = new genlist<T>();
	list.add(2);
	list.add(3);
	return 0;
}//Main

*/


}
