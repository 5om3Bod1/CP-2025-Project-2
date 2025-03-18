using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int questionDone;
    public GameObject[] equation;

    public static gameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(questionDone == 3) //Add
        {
            equation[0].SetActive(false);
            equation[1].SetActive(true);
        }
        else if(questionDone == 6) //Sub
        {
            equation[1].SetActive(false);
            equation[2].SetActive(true);
        }
        else if (questionDone == 9) //Multi
        {
            equation[2].SetActive(false);
            equation[3].SetActive(true);
        }
        else if (questionDone == 12) //Div
        {
            equation[3].SetActive(false);
            equation[4].SetActive(true);
        }
        else if (questionDone == 15) //Div
        {
            equation[4].SetActive(false);
            equation[0].SetActive(true);
            questionDone = 0;
        }
    }
}
