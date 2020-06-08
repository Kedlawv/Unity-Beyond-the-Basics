using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Shape, IKillable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(this.InternalOutputText);
    }

    private void MoveEnemy(TextOutputHandler outputHandler)
    {
        this.transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = this.transform.position.y - halfHeight;

        if(bottom <= -gameSceneController.screenBounds.y)
        {
            outputHandler("Enemy at bottom");
            gameSceneController.KillObject(this);
        }
    }

    private void InternalOutputText(string output)
    {
        Debug.LogFormat("{0} output by EnemyController", output);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public string GetName()
    {
        return Name;
    }
}
