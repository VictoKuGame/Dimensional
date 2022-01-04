using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GenerationLoadingWait : MonoBehaviour
{
    public int seconds;
    public bool showLoader;
    void Start()
    {
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(seconds);
        if (showLoader)
        {
            SceneManager.LoadScene("MainGame1");
        }
    }
}





