using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class medInput0 : MonoBehaviour
{
    public string currentInput = "";
    public TMP_Text playerString0;
    public int endAmount;
    public string conNum;
    public int parNum;

    public int valNum;

    public static medInput0 Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            currentInput += 1;
            updateDisplay();
        }
        else if (Input.GetKeyDown("2"))
        {
            currentInput += 2;
            updateDisplay();
        }
        else if (Input.GetKeyDown("3"))
        {
            currentInput += 3;
            updateDisplay();
        }
        else if (Input.GetKeyDown("4"))
        {
            currentInput += 4;
            updateDisplay();
        }
        else if (Input.GetKeyDown("5"))
        {
            currentInput += 5;
            updateDisplay();
        }
        else if (Input.GetKeyDown("6"))
        {
            currentInput += 6;
            updateDisplay();
        }
        else if (Input.GetKeyDown("7"))
        {
            currentInput += 7;
            updateDisplay();
        }
        else if (Input.GetKeyDown("8"))
        {
            currentInput += 8;
            updateDisplay();
        }
        else if (Input.GetKeyDown("9"))
        {
            currentInput += 9;
            updateDisplay();
        }
        else if (Input.GetKeyDown("0"))
        {
            currentInput += 0;
            updateDisplay();
        }
        else if (Input.GetKeyDown("w")) //Subtract
        {
            currentInput += "-";
            updateDisplay();
        }
        else if (Input.GetKeyDown("a")) //Equal
        {
            mediumQuestion.Instance.valNum+=2;
            mediumQuestion.Instance.valCheck();
        }
        else if (Input.GetKeyDown("s")) //Clear
        {
            clearInput();
        }
    }
    void clearInput()
    {
        currentInput = "";
        updateDisplay();
    }
    private void updateDisplay()
    {
        playerString0.text = currentInput;
        mediumQuestion.Instance.answerZ = currentInput;
    }
}
