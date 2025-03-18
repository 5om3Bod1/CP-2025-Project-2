using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO.Ports;
using System.Threading;

public class eDivison : MonoBehaviour
{
    public int[] number;
    public float endAmount = 0.0f;
    public TMP_Text equationString;
    public TMP_Text playerString;
    public string currentInput = "";
    private string conNum;

    public int qNum;

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
        qNum = Random.Range(0, 5 + 1);
        if(qNum == 0)
        {
            equationString.text = (10 + " / " + 2);
            endAmount = 5;
        }
        else if (qNum == 1)
        {
            equationString.text = (9 + " / " + 3);
            endAmount = 3;
        }
        else if (qNum == 2)
        {
            equationString.text = (8 + " / " + 2);
            endAmount = 4;
        }
        else if (qNum == 3)
        {
            equationString.text = (6 + " / " + 6);
            endAmount = 1;
        }
        else if (qNum == 4)
        {
            equationString.text = (2 + " / " + 1);
            endAmount = 2;
        }
        else if (qNum == 5)
        {
            equationString.text = (5 + " / " + 5);
            endAmount = 1;
        }
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
