using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class calcScript : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    private string currentInput = "";

    private double result = 0.0;

    private void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            currentInput += 0;
            updateDisplay();
        }
        else if (Input.GetKeyDown("1"))
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
        else if (Input.GetKeyDown("e")) //Multiply
        {
            currentInput += "*";
            updateDisplay();
        }
        else if (Input.GetKeyDown("r")) //Divide
        {
            currentInput += "/";
            updateDisplay();
        }
        else if (Input.GetKeyDown("a")) //qual
        {
            calcResult();
        }
        else if (Input.GetKeyDown("s")) //Clear
        {
            clearInput();
        }
    }
    /*
    public void OnButtonClick(string buttonValue)
    {
        if(buttonValue == "=")
        {
            calcResult();
        }
        else if(buttonValue == "C")
        {
            clearInput();
        }
        else
        {
            currentInput += buttonValue;
            updateDisplay();
        }
    }
    */
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
