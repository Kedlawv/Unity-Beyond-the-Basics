using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : Shape
{
    public Vector2 projectileDirection;
    public float projectileSpeed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetColor(0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        this.transform.Translate(projectileDirection * Time.deltaTime * projectileSpeed, Space.World);
        float top = this.transform.position.y + halfHeight;

        if (top >= gameSceneController.screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
}
