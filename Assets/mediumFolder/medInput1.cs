using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO.Ports;
using System.Threading;

public class medInput1 : MonoBehaviour
{
    public string currentInput = "";
    public TMP_Text playerString1;
    public int endAmount;
    public string conNum;
    public int parNum;

    public int valNum;

    public static medInput1 Instance { get; private set; }

    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sy;
    private static string incomingMs = "";
    #endregion
    #region portInfo
    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sy = new SerialPort("/dev/cu.usbmodem1101", 9600);
        sy.Open();

        while (true)
        {
            incomingMs = sy.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sy != null && sy.IsOpen)
        {
            sy.Close();
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        IOThread.Start();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(incomingMs))
        {
            string trimmedMsg = incomingMs.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

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
                else if (messageInt == 0)
                {
                    processed = true;

                    currentInput += 0;
                    updateDisplay();
                }
                else if (messageInt == 14) //Equal
                {
                    processed = true;

                    mediumQuestion.Instance.valNum += 2;
                    mediumQuestion.Instance.valCheck();
                }
                if (processed)
                {
                    incomingMs = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }

    }
    public void clearInput()
    {
        currentInput = "";
        updateDisplay();
    }
    public void updateDisplay()
    {
        playerString1.text = currentInput;
        mediumQuestion.Instance.answerZ = currentInput;
    }
}
