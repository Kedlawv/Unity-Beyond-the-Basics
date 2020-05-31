using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMethodExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float floatValue = 13.5f;
        Vector3 aVector3 = new Vector3(1, 2, 3);

        Evaluate(floatValue);
        Evaluate(aVector3);
        Evaluate(5);
        Evaluate("String");
    }

    private void Evaluate<T>(T suppliedValue)
    {
        Debug.LogFormat("the type of {0} is {1}", suppliedValue, typeof(T));
    }
}
