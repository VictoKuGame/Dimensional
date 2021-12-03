using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GenerationLoadingWait : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Loading());
        
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");

    }
}










