using System;
using System.Collections;

public class Person
{
    public string firstName;
    public string lastName;
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }
}

public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for(int i=0; i<pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new PeopleEnum(_people);
    }

}

public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    int pos = -1;

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    public bool MoveNext() {
        pos++;
        return (pos < _people.Length);
    }

    public void Reset()
    {
        pos = -1;
    }

    public object Current
    {
        get
        {
            try
            {
                return _people[pos];
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    static void Main(string[] args)
    {
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

        People peopleList = new People(peopleArray);
        foreach(Person p in peopleList) { 
            Console.WriteLine(p.firstName + " " + p.lastName);
        }
    }

}
