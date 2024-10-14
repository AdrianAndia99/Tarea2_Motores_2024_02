using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClipSO clipMenu;
    [SerializeField] private AudioClipSO clipGame;
    [SerializeField] private AudioClipSO clipOver;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if(currentScene == "Menu")
        {
            clipMenu.PlayLoop();
        }
        else if(currentScene == "Game")
        {
            clipGame.PlayLoop();
        }
        else if(currentScene == "GameOver")
        {
            clipOver.PlayOneShoot();
        }
    }
}