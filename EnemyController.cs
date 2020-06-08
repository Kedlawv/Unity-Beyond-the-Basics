﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Shape
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        this.transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = this.transform.position.y - halfHeight;

        if(bottom <= -gameSceneController.screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
}
