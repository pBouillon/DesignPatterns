// Usage
void Main()
{
    var primes = new NumberArray(3);
    primes.Set(1, 0);
    primes.Set(3, 1);
    primes.Set(5, 2);

    var iterator = primes.GetIterator();
    while (iterator.HasNext())
    {
        iterator.Next().Dump();
    }
}


// Iterator
public interface NumberIterator
{
    bool HasNext();
    int? Next();
}

public class NumberArrayIterator : NumberIterator
{
    int _offset;
    readonly int[] _array;

    public NumberArrayIterator(int[] array)
        => (_array, _offset) = (array, 0);

    public bool HasNext()
        => _offset < _array.Length;

    public int? Next()
        => HasNext() ? _array[_offset++] : null;
}


// Container
public interface Container
{
    NumberIterator GetIterator();
}

public class NumberArray : Container
{
    readonly int[] _array;

    public NumberArray(int size)
        => _array = new int[size];

    public NumberIterator GetIterator()
        => new NumberArrayIterator(_array);

    public void Set(int item, int offset)
        => _array[offset] = item;
}
