using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
    GameSceneController gameSceneController;
    // Start is called before the first frame update
    void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
        this.SetColor(Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed;
            horizontalMovement += this.transform.position.x;

            this.transform.position = new Vector2(horizontalMovement, this.transform.position.y);
        }
    }
}
