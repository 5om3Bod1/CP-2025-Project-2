using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class mdInput1 : MonoBehaviour
{
    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sz;
    private static string incomingM = "";
    #endregion
    #region portInfo
    private static void DataThread()
    {
        // Mac - /dev/cu.usbmodem1101
        // PC - COM
        sz = new SerialPort("/dev/cu.usbmodem101", 9600);
        sz.Open();

        while (true)
        {
            incomingM = sz.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        if (IOThread != null && IOThread.IsAlive)
        {
            IOThread.Abort();
        }

        if (sz != null && sz.IsOpen)
        {
            sz.Close();
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(incomingM))
        {
            string trimmedMsg = incomingM.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 11) //Subtract
                {
                    processed = true;

                    medInput0.Instance.currentInput += "-";
                    medInput0.Instance.updateDisplay();
                }
                else if (messageInt == 15) //Clear
                {
                    processed = true;

                    medInput0.Instance.clearInput();
                }
                if (processed)
                {
                    incomingM = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }

    }
}
