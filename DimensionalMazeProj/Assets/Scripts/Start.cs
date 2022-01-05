using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public GameObject rules;
    void Awake()
    {
        closeRules();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void MainGame1()
    {
        SceneManager.LoadScene("MainGame1");
    }
    public void Rules()
    {
        rules.SetActive(true);
    }
    public void closeRules()
    {
        rules.SetActive(false);
    }
}
