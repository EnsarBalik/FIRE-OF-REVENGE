using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Portal : MonoBehaviour
{
    public GameObject LoadingScreen;
    public float second;
    public GameObject PressX;
    private bool IsActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PressX.SetActive(true);
            IsActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PressX.SetActive(false);
            IsActive = false;
        }
    }
    private void Update()
    {
        if (IsActive==true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                load();
            }
        }
    }
    public void load()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene("Level2");
        yield break;
    }

}
