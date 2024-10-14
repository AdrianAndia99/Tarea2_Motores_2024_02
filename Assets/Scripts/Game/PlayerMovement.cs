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
    [SerializeField] private AudioClipSO Candy;
    [SerializeField] private AudioClipSO Enemy;
    [SerializeField] private AudioClipSO Coffee;
    [SerializeField] private AudioClipSO Mushroom;
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
            Candy.PlayOneShoot();
        }
        if (other.tag == "Enemy")
        {
            EnemyGenerator.instance.ManageEnemy(other.gameObject.GetComponent<EnemyController>(), this);
            Enemy.PlayOneShoot();

        }
        if (other.tag == "Coffee")
        {
            PowerGenerator.instance.ManagePower(other.gameObject.GetComponent<PowerController>(), this);
            Coffee.PlayOneShoot();
        }
        if (other.tag == "Mushroom")
        {
            PowerGenerator.instance.ManagePower(other.gameObject.GetComponent<PowerController>(), this);
            Mushroom.PlayOneShoot();
        }
    }
}