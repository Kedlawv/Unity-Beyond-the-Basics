using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void EnemyEscapedHandler(EnemyController enemy);
public class EnemyController : Shape, IKillable
{
    public event EnemyEscapedHandler EnemyEscaped;
    public event Action<int> EnemyKilled;  // Action event does not need an explicit delegate declaration 
                                            // return type is void by default and parameter is generic

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(EnemyKilled != null)
        {
            EnemyKilled(10);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void MoveEnemy()
    {
        this.transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = this.transform.position.y - halfHeight;

        if(bottom <= -gameSceneController.screenBounds.y)
        {
            if (EnemyEscaped != null)
            {
                EnemyEscaped(this); 
            }
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
