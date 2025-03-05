using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eAddition : MonoBehaviour
{
    public int[] number;
    public int endAmount;
    public TMP_Text equationString;
    public TMP_Text playerString;
    public string currentInput = "";
    private string conNum;

    private void Start()
    {
        scramble();
    }
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
        else if (Input.GetKeyDown("a")) //Equal
        {
            winCheck();
        }
        else if (Input.GetKeyDown("s")) //Clear
        {
            clearInput();
        }
    }
    void scramble()
    {
        number[0] = Random.Range(0, 10 + 1);
        number[1] = Random.Range(0, 10 + 1);
        number[2] = Random.Range(0, 10 + 1);
        equationString.text = (number[0] + " + " + number[1] + " + " + number[2]);
        endAmount = number[0] + number[1] + number[2];
    }
    void winCheck()
    {
        conNum = endAmount.ToString();
        Debug.Log(conNum);
        Debug.Log(endAmount);
        if (currentInput == conNum)
        {
            Debug.Log("You win!");
            scramble();
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
        playerString.text = currentInput;
    }
}
