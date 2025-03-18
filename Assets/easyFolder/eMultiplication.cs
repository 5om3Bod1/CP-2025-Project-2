using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO.Ports;
using System.Threading;

public class eMultiplication : MonoBehaviour
{
    public int[] number;
    public int endAmount;
    public TMP_Text equationString;
    public TMP_Text playerString;
    public string currentInput = "";
    private string conNum;

    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    public bool processed;
    #endregion

    #region portInfo
    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sp = new SerialPort("/dev/cu.usbmodem101", 9600);
        sp.Open();

        while (true)
        {
            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sp != null && sp.IsOpen)
        {
            sp.Close();
        }
    }
    #endregion

    private void Start()
    {
        scramble();
    }
    private void Update()
    {
        if (!string.IsNullOrEmpty(incomingMsg))
        {
            string trimmedMsg = incomingMsg.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                processed = false;

                if (messageInt == 1)
                {
                    processed = true;

                    currentInput += 1;
                    updateDisplay();
                }
                else if (messageInt == 2)
                {
                    processed = true;

                    currentInput += 2;
                    updateDisplay();
                }
                else if (messageInt == 3)
                {
                    processed = true;

                    currentInput += 3;
                    updateDisplay();
                }
                else if (messageInt == 4)
                {
                    processed = true;

                    currentInput += 4;
                    updateDisplay();
                }
                else if (messageInt == 5)
                {
                    processed = true;

                    currentInput += 5;
                    updateDisplay();
                }
                else if (messageInt == 6)
                {
                    processed = true;

                    currentInput += 6;
                    updateDisplay();
                }
                else if (messageInt == 7)
                {
                    processed = true;

                    currentInput += 7;
                    updateDisplay();
                }
                else if (messageInt == 8)
                {
                    processed = true;

                    currentInput += 8;
                    updateDisplay();
                }
                else if (messageInt == 9)
                {
                    processed = true;

                    currentInput += 9;
                    updateDisplay();
                }
            }
        }
        if (Input.GetKeyDown("0"))
        {
            currentInput += 0;
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
        equationString.text = (number[0] + " * " + number[1]);
        endAmount = number[0] * number[1];
    }
    void winCheck()
    {
        conNum = endAmount.ToString();
        Debug.Log(conNum);
        Debug.Log(endAmount);
        if (currentInput == conNum)
        {
            Debug.Log("You win!");
            gameManager.Instance.questionDone++;
            scramble();
            clearInput();
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
        updateDisplay();
    }
    private void updateDisplay()
    {
        playerString.text = currentInput;
    }
}
