using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    public static PowerGenerator instance;
    public List<GameObject> PowerUP = new List<GameObject>();
    private float time_to_create = 10f;
    private float actual_time = 0f;
    private float limitSuperior;
    private float limitInferior;
    public List<GameObject> ActualPower = new List<GameObject>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        SetMinMax();
    }
    void Update()
    {
        actual_time += Time.deltaTime;
        if (time_to_create <= actual_time)
        {
            GameObject powerUP = Instantiate(PowerUP[Random.Range(0, PowerUP.Count)],
            new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
            powerUP.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
            actual_time = 0f;
            ActualPower.Add(powerUP);

        }
    }
    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    public void ManagePower(PowerController powerScript, PlayerMovement playerScript = null)
    {
        if (playerScript == null)
        {
            Destroy(powerScript.gameObject);
            return;
        }

        Destroy(powerScript.gameObject);
    }
}