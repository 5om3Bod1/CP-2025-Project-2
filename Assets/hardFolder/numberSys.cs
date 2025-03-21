using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class numberSys : MonoBehaviour
{
    //Opperation
    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sd;
    private static string incomingMg = "";
    #endregion
    #region portInfo
    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sd = new SerialPort("/dev/cu.usbmodem101", 9600);
        sd.Open();

        while (true)
        {
            incomingMg = sd.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sd != null && sd.IsOpen)
        {
            sd.Close();
        }
    }
    #endregion

    void Start()
    {
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(incomingMg))
        {
            string trimmedMsg = incomingMg.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 10) //Add
                {
                    processed = true;

                    if (calcScript.Instance.doubleOpp == false)
                    {
                        calcScript.Instance.currentInput += "+";
                        doubleCheck();
                    }
                }
                else if (messageInt == 11) //Sub
                {
                    processed = true;

                    if (calcScript.Instance.doubleOpp == false)
                    {
                        calcScript.Instance.currentInput += "-";
                        doubleCheck();
                    }
                }
                else if (messageInt == 12) //Multi
                {
                    processed = true;

                    if (calcScript.Instance.doubleOpp == false)
                    {
                        calcScript.Instance.currentInput += "*";
                        doubleCheck();
                    }
                }
                else if (messageInt == 13) //Divide
                {
                    processed = true;

                    if (calcScript.Instance.doubleOpp == false)
                    {
                        calcScript.Instance.currentInput += "/";
                        doubleCheck();
                    }
                }
                else if (messageInt == 15) //Clear
                {
                    processed = true;
                    calcScript.Instance.clearInput();
                }

                if (processed)
                {
                    incomingMg = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }
    }

    void doubleCheck()
    {
        calcScript.Instance.updateDisplay();
        calcScript.Instance.operationAmount++;
        calcScript.Instance.doubleD = false;
        calcScript.Instance.doubleOpp = true;
    }
}