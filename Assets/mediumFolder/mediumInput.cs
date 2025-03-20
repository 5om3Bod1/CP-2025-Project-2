using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mediumInput : MonoBehaviour
{
    public string currentInput = "";
    public TMP_Text playerString;
    public int endAmount;
    public string conNum;
    public int parNum;

    public int valNum;

    public static mediumInput Instance { get; private set; }

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
        else if (Input.GetKeyDown("q")) //Add
        {
            currentInput += "+";
            updateDisplay();
        }
        else if (Input.GetKeyDown("w")) //Subtract
        {
            currentInput += "-";
            updateDisplay();
        }
        else if (Input.GetKeyDown("e")) //Multiple
        {
            currentInput += "*";
            updateDisplay();
        }
        else if (Input.GetKeyDown("r")) //Subtract
        {
            currentInput += "/";
            updateDisplay();
        }
        else if (Input.GetKeyDown("a")) //Equal
        {
            if(valNum > 2)
            {
                valNum++;
            }
            else if(valNum <= 2)
            {
                winCheck();
            }
        }
        else if (Input.GetKeyDown("s")) //Clear
        {
            clearInput();
        }
    }
    void winCheck() //If both answer 1 and answer 2 are the same they pass, if not errr. I can add a massive if statement in update but wouldnt that be slow?
    {
        if (parNum == endAmount) //Number Inputs
        {
            Debug.Log("You win!");
            clearInput();
            easyQuestion.Instance.scramble();
        }
        else if (currentInput == conNum) //Opperation Inputs
        {
            Debug.Log("You win!");
            clearInput();
            easyQuestion.Instance.scramble();
        }
        else
        {
            tryAgain();
        }
    }
    void tryAgain()
    {
        currentInput = "Try again!";
        updateDisplay();
        Invoke("clearInput", 1f);
    }
    void clearInput()
    {
        currentInput = "";
        if(valNum > 0)
        {
            valNum--;
        }
        updateDisplay();
    }
    private void updateDisplay()
    {
        playerString.text = currentInput;
    }
}
