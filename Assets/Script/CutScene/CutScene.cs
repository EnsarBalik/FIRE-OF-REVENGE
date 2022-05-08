using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public static CutScene instance;

    public GameObject BossHealth;
    public GameObject MainCam;
    public GameObject CinematicCam;
    public float second;
    public bool isCinematic;

    public void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isCinematic = true;
            MainCam.SetActive(false);
            CinematicCam.SetActive(true);
            BossHealth.SetActive(true);
            //Dialog.SetActive(true);
            StartCoroutine(CloseCinematic());
        }
    }

    IEnumerator CloseCinematic()
    {
        yield return new WaitForSeconds(second);
        CinematicCam.SetActive(false);
        MainCam.SetActive(true);
        isCinematic = false;
        //Dialog.SetActive(false);
        Destroy(gameObject);
        yield break;
    }
}
