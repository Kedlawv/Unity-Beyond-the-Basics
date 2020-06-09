using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text);
public class GameSceneController : MonoBehaviour
{

    public float playerSpeed;
    public Vector3 screenBounds;
    public EnemyController enemyPrefab;
    private HUDController hudController;
    private int totalPoints;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 10f;
        screenBounds = GetScreenBounds();
        hudController = FindObjectOfType<HUDController>();

        StartCoroutine(SpawnEnemies());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(1);

        while (true)
        {
            float horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.EnemyEscaped += EnemyAtBottom; // subscribe the EnamyAtBottom method to execute when EnemyEscaped event is trigered
                                                 // += we can subscribe more than one method to one event

            enemy.EnemyKilled += EnemyKilled; // Action event

            yield return wait;
        }
    }

    private void EnemyKilled(int pointValue)
    {
        totalPoints += pointValue;
        hudController.scoreText.text = totalPoints.ToString();
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        Debug.Log("Enemy escaped!");
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    public void KillObject(IKillable killable)
    {
        killable.Kill();
    }

    public void OutputText(string output)
    {
        Debug.LogFormat("{0} output by game controller", output);
    }
}
