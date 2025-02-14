using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class calcScript : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public TMP_Text qOne;
    public TMP_Text start;
    public TMP_Text end;

    private string currentInput = "";

    private double result = 0.0;

    public int operationAmount;
    public int operationReq;
    public int startAmount;
    public int endAmount;

    public bool doubleD;

    public int challenegeDone;
    public GameObject[] challenegeNum;
    public GameObject youWin;

    public static calcScript Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            currentInput += 0;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("1"))
        {
            currentInput += 1;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            currentInput += 2;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            currentInput += 3;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("4"))
        {
            currentInput += 4;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("5"))
        {
            currentInput += 5;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("6"))
        {
            currentInput += 6;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("7"))
        {
            currentInput += 7;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("8"))
        {
            currentInput += 8;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("9"))
        {
            currentInput += 9;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
        }
        else if (Input.GetKeyDown("q")) //Add
        {
            currentInput += "+";
            updateDisplay();
            doubleD = false;
            operationAmount++;
        }
        else if (Input.GetKeyDown("w")) //Subtract
        {
            currentInput += "-";
            updateDisplay();
            operationAmount++;
            doubleD = false;
        }
        else if (Input.GetKeyDown("e")) //Multiply
        {
            currentInput += "*";
            updateDisplay();
            operationAmount++;
            doubleD = false;
        }
        else if (Input.GetKeyDown("r")) //Divide
        {
            currentInput += "/";
            updateDisplay();
            operationAmount++;
            doubleD = false;
        }
        else if (Input.GetKeyDown("a")) //equal
        {
            calcResult();
            doubleD = false;

            if (operationAmount != operationReq)
            {
                Invoke("tryAgain", 2f);
            }
            else if(operationAmount == operationReq && challenegeDone == 0 && result == endAmount) //Challenege #1 Done
            {
                challenegeNum[0].SetActive(false);
                challenegeNum[1].SetActive(true);
                challenegeDone++;
                clearInput();
            }
            else if(operationAmount == operationReq && challenegeDone == 1 && result == endAmount) //Challenege #2 Done
            {
                challenegeNum[1].SetActive(false);
                challenegeNum[2].SetActive(true);
                challenegeDone++;
                clearInput();
            }
            else if (operationAmount == operationReq && challenegeDone == 2 && result == endAmount) //Challenege #3 Done
            {
                //Change to Win Screne
                youWin.SetActive(true);
            }
        }
        else if (Input.GetKeyDown("s")) //Clear
        {
            clearInput();
            operationAmount = 0;
            doubleD = false;
        }

        qOne.text = operationAmount.ToString();
    }

    public void calcResult()
    {
        try
        {
            result = System.Convert.ToDouble(new System.Data.DataTable().Compute(currentInput, ""));

            currentInput = result.ToString();
            updateDisplay();
        }

        catch (System.Exception)
        {
            currentInput = "Error";
            updateDisplay();
        }
    }

    void tryAgain()
    {
        currentInput = "";
        result = 0.0;
        updateDisplay();
        operationAmount = 0;
        doubleD = false;
    }
    private void clearInput()
    {
        currentInput = "";
        result = 0.0;
        updateDisplay();
    }
    private void updateDisplay()
    {
        displayText.text = currentInput;
    }
}
