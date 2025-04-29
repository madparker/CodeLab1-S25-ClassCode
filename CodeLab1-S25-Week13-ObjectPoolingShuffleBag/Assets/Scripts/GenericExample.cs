using UnityEngine;

public class GenericExample<Type>
{

    public Type varOfType;

    public Type VarOfType
    {
        get
        {
            Debug.Log("You just got a var of type: " + typeof(Type));
            return varOfType;
        }
        set
        {
            Debug.Log("You just set a var of type: " + typeof(Type));
            varOfType = value;
        }
    }

    public Type Get()
    {
        return VarOfType;
    }

    public void Set(Type t)
    {
        VarOfType = t;
    }
}
