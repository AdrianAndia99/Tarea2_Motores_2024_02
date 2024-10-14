using UnityEngine;

public class ButonController : MonoBehaviour
{
    public void StopTime()
    {
        Time.timeScale = 0.0f;
    }

    public void PlayTime()
    {
        Time.timeScale = 1.0f;
    }
}