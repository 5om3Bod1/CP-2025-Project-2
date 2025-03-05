using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class challenegeThree : MonoBehaviour
{
    //Can't add or divide and 9 inputs

    public int startNum;
    public int endNum;

    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";

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
        calcScript.Instance.operationAmount = 0;
        calcScript.Instance.operationReq = 7;
        startNum = Random.Range(0, 10);
        endNum = Random.Range(0, 10);

        calcScript.Instance.start.text = startNum.ToString();
        calcScript.Instance.end.text = endNum.ToString();
        calcScript.Instance.startAmount = startNum;
        calcScript.Instance.endAmount = endNum;
    }
    void Update()
    {
        if (Input.GetKeyDown("r")) //Divide
        {
            calcScript.Instance.loseCon = true;
            Debug.Log("Complete");
        }

        if (!string.IsNullOrEmpty(incomingMsg))
        {
            string trimmedMsg = incomingMsg.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 10) //Add
                {
                    processed = true;
                    calcScript.Instance.loseCon = true;
                    Debug.Log("Complete");
                }
                if (processed)
                {
                    incomingMsg = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }
    }
}
