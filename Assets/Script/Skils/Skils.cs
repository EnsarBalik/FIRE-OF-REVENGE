using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skils : MonoBehaviour
{
    public static Skils instance;
    public Animator animator;
    public bool isUsedSkill1 = false;


    [Header("Abiliy1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    [Header("Abiliy2")]
    public Image abilityImage2;
    public float cooldown2 = 1.5f;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Abiliy5")]
    public Image abilityImage5;
    public float cooldown5 = 3;
    bool isCooldown5 = false;
    public KeyCode ability5;

    private void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage5.fillAmount = 0;
    }

    private void Update()
    {
        Ability1();
        Ability2();
        Ability5();
    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            isUsedSkill1 = true;
            PlayerMove.instancee.animator.SetTrigger("AttackPer2");
        }
        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
                isUsedSkill1 = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
            //dash
            PlayerMove.instancee.DashSkill();
        }
        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability5()
    {
        if (Input.GetKey(ability5) && isCooldown5 == false)
        {
            isCooldown5 = true;
            abilityImage5.fillAmount = 1;
            if (GameManager.instance.HealthHak >= 1)
            {
                if (PlayerMove.instancee.Health < 6)
                {
                    GameManager.instance.HealthHak--;
                    PlayerMove.instancee.Health++;
                    animator.SetTrigger("Health");
                }
            }
            else if(GameManager.instance.HealthHak <= 0)
            {
                Debug.Log("Hak yok");
            }
            
        }
        if (isCooldown5)
        {
            abilityImage5.fillAmount -= 1 / cooldown5 * Time.deltaTime;
            if (abilityImage5.fillAmount <= 0)
            {
                abilityImage5.fillAmount = 0;
                isCooldown5 = false;
            }
        }
    }
}
