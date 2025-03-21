using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class mdInput0 : MonoBehaviour
{
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

    // Start is called before the first frame update
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
                    incomingMg = "";
                }
            }
            else
            {
                Debug.LogError("Failed to parse input: " + trimmedMsg);
            }
        }

    }
}
