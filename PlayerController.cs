using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
    public ProjectileController projectilePrefab;

    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        SetColor(Color.yellow);
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed;
            horizontalMovement += this.transform.position.x;

            float right = gameSceneController.screenBounds.x - halfWidth;
            float left = -right;
            float limit = Mathf.Clamp(horizontalMovement, left, right);

            this.transform.position = new Vector2(limit, this.transform.position.y);
        }
    }

    private void FireProjectile()
    {
        Vector2 spawnPosition = this.transform.position;

        ProjectileController projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        projectile.projectileSpeed = 2;
        projectile.projectileDirection = Vector2.up;
    }
}
