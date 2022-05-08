using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderLevels : MonoBehaviour
{
    public GameObject LoadingScreen;
    public float second;

    public void load()
    {
        Time.timeScale = 1;
        LoadingScreen.SetActive(true);
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene("MainMenu");
        yield break;
    }
}
