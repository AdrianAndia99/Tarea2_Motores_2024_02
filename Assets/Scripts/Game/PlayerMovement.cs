using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 3;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public AudioSource AudioSource3;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        myRB.velocity = new Vector2(0, input.y * speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
            AudioSource2.Play();
        }
        if (other.tag == "Enemy")
        {
            EnemyGenerator.instance.ManageEnemy(other.gameObject.GetComponent<EnemyController>(), this);
            AudioSource1.Play();

        }
        if (other.tag == "Power")
        {
            PowerGenerator.instance.ManagePower(other.gameObject.GetComponent<PowerController>(), this);
            AudioSource3.Play();
        }
    }
}