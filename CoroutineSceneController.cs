using System.Collections;
using System.Collections.Generic;
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
            //SetShapesRed();
            StartCoroutine(SetShapesBlue());
        }
        
    }

    private IEnumerator SetShapesBlue()
    {
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
        foreach(Shape shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}
