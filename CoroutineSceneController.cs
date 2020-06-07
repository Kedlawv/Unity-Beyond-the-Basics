using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public Coroutine countToNumberCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countToNumberCoroutine = StartCoroutine(CountToNumber(2500)); // returns a referance to the started coroutine
            
            // StartCoroutine("CountToNumber",2500); // name of the coroutine to start as string and argument to the coroutine as second 
                                                    // argument to StartCoroutine
            // StartCoroutine(CountToNumber(2500)); // method call returning IEnumerator
            StartCoroutine(SetShapesBlue());
            Debug.Log("Keypress completed");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // StopAllCoroutines();
            //StopCoroutine("CountToNumber"); //works only if the coroutine was started using a string literal as well
            StopCoroutine(countToNumberCoroutine); // stopping a coroutine by passing a reference to the coroutine we want to stop
        }

    }

    private IEnumerator CountToNumber(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Debug.Log(i);
            yield return null;
        }
    }

    private IEnumerator SetShapesBlue()
    {
        Debug.Log("Start changing colors.");

        foreach (Shape shape in gameShapes)
        {
            shape.SetColor(Color.blue);
            yield return new WaitForSeconds(1);
            shape.SetColor(Color.white);
        }

        yield return new WaitForSeconds(1);
        Debug.Log("I just wasted a second");

        yield return StartCoroutine(SetShapesBlue());
    }

    private void SetShapesRed()
    {
        foreach (Shape shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}
