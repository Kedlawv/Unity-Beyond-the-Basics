using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] // checks for a component on a game object. If script is added to an existing game object
                                            // unity will add automatically the missing component
public class StopController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
