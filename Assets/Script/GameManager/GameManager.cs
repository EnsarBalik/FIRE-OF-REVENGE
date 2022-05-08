using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Control;
    public GameObject PauseScreen;
    public GameObject LoseUI;
    public GameObject WinUI;
    public Animator PauseAnim;
    public float HealthHak;
    public TextMeshProUGUI HealthHakki;
    public bool IsBossDead = false;

    private void Start()
    {
        instance = this;
        HealthHak = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        HealthHakki.text = "x" + HealthHak;

        if (PlayerMove.instancee.Health <= 0)
        {
            LoseUI.SetActive(true);
        }
        if(BOSS.instatee.Health <= 0)
        {
            IsBossDead = true;
            if (IsBossDead == true)
            {
                WinUI.SetActive(true);
            }
        }
    }

    //-------------------PauseScreen-----------------
    public void Controls()
    {
        Control.SetActive(true);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        Control.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PauseAnim.SetBool("PuaseClosed", true);
        StartCoroutine(Pause());
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        PauseScreen.SetActive(false);
        Control.SetActive(false);
        yield break;
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
