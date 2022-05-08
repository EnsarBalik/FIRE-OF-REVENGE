using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreenM : MonoBehaviour
{
    public GameObject LoadingScreen;
    public float second;

    public void load()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene("Level1");
        yield break;
    }
}
