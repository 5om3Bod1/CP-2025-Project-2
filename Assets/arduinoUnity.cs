using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class arduinoUnity : MonoBehaviour
{
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

    private void Start()
    {
        IOThread.Start();
    }

    void Update()
    {
        if (!string.IsNullOrEmpty(incomingMsg))
        {
            string trimmedMsg = incomingMsg.Trim();

            if (int.TryParse(trimmedMsg, out messageInt))
            {
                Debug.Log(messageInt);

                bool processed = false;

                if (messageInt == 1)
                {
                    processed = true;
                    //Call on a function, that includes Invoke("Off",1f)
                }
                else if (messageInt == 2)
                {
                    processed = true;
                    //Call on a function, that includes Invoke("Off",1f)
                }
                else if (messageInt == 3)
                {
                    processed = true;
                    //Call on a function, that includes Invoke("Off",1f)
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