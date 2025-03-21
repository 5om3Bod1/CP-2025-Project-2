using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class challengeFour : MonoBehaviour
{
    //Can't subtract or multiply and 6 inputs

    public int startNum;
    public int endNum;

    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sFour;
    private static string incomingFour = "";

    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sFour = new SerialPort("/dev/cu.usbmodem101", 9600);
        sFour.Open();

        while (true)
        {
            incomingFour = sFour.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sFour != null && sFour.IsOpen)
        {
            sFour.Close();
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
        if (!string.IsNullOrEmpty(incomingFour))
        {
            string trimmedMsg = incomingFour.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 11)
                {
                    processed = true;

                    calcScript.Instance.loseCon = true;
                }
                else if (messageInt == 12)
                {
                    processed = true;

                    calcScript.Instance.loseCon = true;
                }
                if (processed)
                {
                    incomingFour = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }
    }
}
