using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class challenegeTwo : MonoBehaviour
{
    //Must multiply or divide and 6 inputs

    public int startNum;
    public int endNum;

    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sTwo;
    private static string incomingTwo = "";

    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sTwo = new SerialPort("/dev/cu.usbmodem101", 9600);
        sTwo.Open();

        while (true)
        {
            incomingTwo = sTwo.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sTwo != null && sTwo.IsOpen)
        {
            sTwo.Close();
        }
    }
    #endregion

    private void Start()
    {
        calcScript.Instance.operationAmount = 0;
        calcScript.Instance.operationReq = 6;
        startNum = Random.Range(0, 10);
        endNum = Random.Range(0, 10);

        calcScript.Instance.start.text = startNum.ToString();
        calcScript.Instance.end.text = endNum.ToString();
        calcScript.Instance.startAmount = startNum;
        calcScript.Instance.endAmount = endNum;
        calcScript.Instance.currentInput += startNum;
    }
    void Update()
    {
        if (!string.IsNullOrEmpty(incomingTwo))
        {
            string trimmedMsg = incomingTwo.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 12)
                {
                    processed = true;

                    calcScript.Instance.winCon = true;
                }
                else if (messageInt == 13) //Divide
                {
                    processed = true;

                    calcScript.Instance.winCon = true;
                }
                if (processed)
                {
                    incomingTwo = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }
    }
}
