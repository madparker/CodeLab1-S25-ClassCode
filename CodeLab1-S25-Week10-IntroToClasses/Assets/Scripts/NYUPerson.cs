public class NYUPerson
{
    public string netId;
    public string name;
    public long nNumber;
    public float age;

    //Default or empty constructor
    public NYUPerson()
    {
    }

    //Constructor that takes arugemnts
    public NYUPerson(string netId, string name, 
        long nNumber, float age)
    {
        this.netId = netId;
        this.name = name;
        this.nNumber = nNumber;
        this.age = age;
    }

    public virtual string GetRecord()
    {
        string result =
            "Name: " + name + "\n" +
            "NetID: " + netId + "\n" +
            "Age: " + age + "\n" +
            "N Num" + nNumber + "\n";

        return result;
    }
}
