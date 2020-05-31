using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    #region Variable Declarations
    public int numberToDisplay;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SayHelloWorld();
    }

    private void SayHelloWorld()
    {
        for (int i = 0; i < numberToDisplay; i++){
            Debug.Log("Hello World");
        }
    }

    private void AnonymousTypeExample()
    {
        var enemy = new { name = "Monster", hitPoints = 100 };
    }

    
}
