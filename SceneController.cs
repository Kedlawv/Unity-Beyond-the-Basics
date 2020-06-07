using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public string[] shapes = { "circle", "square", "triangle", "octagon" };
    
    public List<string> moreShapes; // populated inside the editor

    public List<Shape> gameShapes;
    public Dictionary<string, Shape> shapeDictionary;

    // Start is called before the first frame update
    void Start()
    {
        shapeDictionary = new Dictionary<string, Shape>();

        foreach(Shape shape in gameShapes)
        {
            shapeDictionary.Add(shape.name, shape);
        }

        ShapesArray();
        ShapesList();
    }

    private void SetRedByName(string shapeName)
    {
        shapeDictionary[shapeName].SetColor(Color.red);
    }
    private void FindExample()
    {
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");
        octagon.SetColor(Color.red);
    }

    private void ShapesArray()
    {
        foreach (string s in shapes)
        {
            Debug.Log(s.ToUpper());
        }
    }

    private void ShapesList()
    {
        moreShapes = new List<string> { "circle", "square", "triangle", "octagon" };
        moreShapes.Add("rectangle");
        moreShapes.Insert(2, "diamond");

        foreach (string s in moreShapes)
        {
            Debug.Log(s.ToLower());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetRedByName("Square");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SetRedByName("Circle");
        }
    }
}
