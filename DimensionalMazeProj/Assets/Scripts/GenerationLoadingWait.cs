using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GenerationLoadingWait : MonoBehaviour
{
    public int seconds;
    private bool continuePressed;
    void Start()
    {
        StartCoroutine(Loading());
        continuePressed = false;
    }
    IEnumerator Loading()
    {
        for (float timer = seconds; timer >= 0; timer -= Time.deltaTime)
        {
            if (continuePressed)
            {
                Continue();
                yield break;
            }
            yield return null;
        }
        Continue();
    }
    public void Continue()
    {
        SceneManager.LoadScene("MainGame1");
    }
}




