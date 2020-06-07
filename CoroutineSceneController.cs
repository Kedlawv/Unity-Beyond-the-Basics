using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CountToNumber(2500));
            StartCoroutine(SetShapesBlue());
            Debug.Log("Keypress completed");
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
    }

    private void SetShapesRed()
    {
        foreach (Shape shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}
