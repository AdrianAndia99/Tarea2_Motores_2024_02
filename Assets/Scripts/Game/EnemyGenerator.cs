using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;
    public List<GameObject> enemies = new List<GameObject>();
    private float time_to_create = 5f;
    private float ActualTime = 0f;
    private float limitSuperior;
    private float limitInferior;
    public List<GameObject> actualEnemy = new List<GameObject>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }
    void Start()
    {
        SetMinMax();
    }

    void Update()
    {
        ActualTime += Time.deltaTime;
        if (time_to_create <= ActualTime)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Count)],
            new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
            ActualTime = 0f;
            actualEnemy.Add(enemy);
        }
    }
    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    public void ManageEnemy(EnemyController enemyScript, PlayerMovement playerScript = null)
    {
        if (playerScript == null)
        {
            Destroy(enemyScript.gameObject);
            return;
        }

        int lives = playerScript.player_lives;
        int liveChange = enemyScript.lifeChanges;
        lives -= liveChange;
        print(lives);

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }
        playerScript.player_lives = lives;
        Destroy(enemyScript.gameObject);
    }
}