using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public string[] shapes = { "circle", "square", "triangle", "octagon" };

    // Start is called before the first frame update
    void Start()
    {
        foreach(string s in shapes)
        {
            Debug.Log(s.ToUpper());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
