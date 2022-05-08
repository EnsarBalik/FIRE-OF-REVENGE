using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        instance = this;
        textComp.text = string.Empty;
        DialogSystem.instance.startDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComp.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }

    public void startDialogue()
    {
        index = 0;
        StartCoroutine(typeLine());
    }

    IEnumerator typeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text=string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
