using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class calcScript : MonoBehaviour
{
    #region Text
    private string currentInput = "";

    public TextMeshProUGUI displayText;
    public TMP_Text qOne;
    public TMP_Text start;
    public TMP_Text end;
    #endregion

    #region Challenges
    public int challenegeDone;
    public GameObject[] challenegeNum;
    public GameObject youWin;
    #endregion

    #region Values
    public int operationAmount;
    public int operationReq;
    public int startAmount;
    public int endAmount;
    
    private double result = 0.0;
    #endregion

    public bool doubleD;
    public bool doubleOpp;

    public static calcScript Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        doubleOpp = true;
    }

    private void Update()
    {
        #region Inputs
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
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
            doubleOpp = false;
        }
        else if (Input.GetKeyDown("q")) //Add
        {
            if (!doubleOpp)
            {
                currentInput += "+";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }

        }
        else if (Input.GetKeyDown("w")) //Subtract
        {
            if (!doubleOpp)
            {
                currentInput += "-";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }
        else if (Input.GetKeyDown("e")) //Multiply
        {
            if (!doubleOpp)
            {
                currentInput += "*";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }
        else if (Input.GetKeyDown("r")) //Divide
        {
            if (!doubleOpp)
            {
                currentInput += "/";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }
        else if (Input.GetKeyDown("a")) //equal
        {
            calcResult();
            doubleD = false;
            doubleOpp = true;

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
            doubleOpp = false;
        }

        qOne.text = operationAmount.ToString();
        #endregion
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
