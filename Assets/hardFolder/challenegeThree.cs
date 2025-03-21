using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class challenegeThree : MonoBehaviour
{
    //Can't add or divide and 6 inputs

    public int startNum;
    public int endNum;

    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sThree;
    private static string incomingThree = "";

    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sThree = new SerialPort("/dev/cu.usbmodem101", 9600);
        sThree.Open();

        while (true)
        {
            incomingThree = sThree.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sThree != null && sThree.IsOpen)
        {
            sThree.Close();
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
        if (!string.IsNullOrEmpty(incomingThree))
        {
            string trimmedMsg = incomingThree.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 10) //Add
                {
                    processed = true;
                    calcScript.Instance.loseCon = true;
                }
                else if (messageInt == 13) //Add
                {
                    processed = true;
                    calcScript.Instance.loseCon = true;
                }
                if (processed)
                {
                    incomingThree = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }
    }
}
