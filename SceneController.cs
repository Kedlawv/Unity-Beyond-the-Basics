using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public string[] shapes = { "circle", "square", "triangle", "octagon" };
    public List<string> moreShapes;

    public List<Shape> gameShapes;
    public Dictionary<string, Shape> shapeDictionary;

    // Start is called before the first frame update
    void Start()
    {
        shapeDictionary = new Dictionary<string, Shape>();
        
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");

        shapeDictionary.Add("Octagon", octagon);
        shapeDictionary["Octagon"].SetColor(Color.blue);

        octagon.SetColor(Color.red);

        ShapesArray();
        ShapesList();
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

    }
}
