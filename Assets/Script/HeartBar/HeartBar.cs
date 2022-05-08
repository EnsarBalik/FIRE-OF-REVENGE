using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    
    public GameObject HeartFul;
    public GameObject HeartHalf;

    void Update()
    {
        //True
        if (PlayerMove.instancee.Health > 5)
        {
            HeartFul.transform.GetChild(2).gameObject.SetActive(true);
        }
        if(PlayerMove.instancee.Health > 4)
        {
            HeartHalf.transform.GetChild(2).gameObject.SetActive(true);
        }
        if(PlayerMove.instancee.Health > 3)
        {
            HeartFul.transform.GetChild(1).gameObject.SetActive(true);
        }
        if(PlayerMove.instancee.Health > 2)
        {
            HeartHalf.transform.GetChild(1).gameObject.SetActive(true);
        }
        if(PlayerMove.instancee.Health > 1)
            HeartFul.transform.GetChild(0).gameObject.SetActive(true);

        if(PlayerMove.instancee.Health > 0)
            HeartHalf.transform.GetChild(0).gameObject.SetActive(true);

        //False
        if (PlayerMove.instancee.Health == 5)
        {
            HeartFul.transform.GetChild(2).gameObject.SetActive(false);
        }
        if(PlayerMove.instancee.Health == 4)
        {
            HeartHalf.transform.GetChild(2).gameObject.SetActive(false);
        }
        if(PlayerMove.instancee.Health == 3)
        {
            HeartFul.transform.GetChild(1).gameObject.SetActive(false);
        }
        if(PlayerMove.instancee.Health == 2)
        {
            HeartHalf.transform.GetChild(1).gameObject.SetActive(false);
        }
        if(PlayerMove.instancee.Health == 1)
        {
            HeartFul.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(PlayerMove.instancee.Health == 0)
        {
            HeartHalf.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    
}
