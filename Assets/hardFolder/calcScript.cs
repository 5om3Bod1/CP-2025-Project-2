using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO.Ports;
using System.Threading;

public class calcScript : MonoBehaviour
{
    #region Text
    private string currentInput = "";

    public TMP_Text displayText;
    public TMP_Text qOne;
    public TMP_Text start;
    public TMP_Text end;
    #endregion
    #region Challenges
    public int challenegeDone;
    public GameObject[] challenegeNum;
    #endregion
    #region Values
    public int operationAmount;
    public int operationReq;
    public int startAmount;
    public int endAmount;
    
    private double result = 0.0;
    #endregion
    #region Bools
    public bool doubleD; //Double Digit
    public bool doubleOpp; //Double opperations, Ex: +-

    public bool winCon;
    public bool loseCon;
    #endregion
    #region Arduino
    int messageInt;

    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    #endregion

    public GameObject congrats;

    public static calcScript Instance { get; private set; }

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

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IOThread.Start();
        doubleOpp = true;
    }

    private void Update()
    {
        #region Inputs
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

                    currentInput += 1;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 2)
                {
                    processed = true;

                    currentInput += 2;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 3)
                {
                    processed = true;

                    currentInput += 3;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 4)
                {
                    processed = true;

                    currentInput += 4;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 5)
                {
                    processed = true;

                    currentInput += 5;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 6)
                {
                    processed = true;

                    currentInput += 6;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 7)
                {
                    processed = true;

                    currentInput += 7;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 8)
                {
                    processed = true;

                    currentInput += 8;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
                }
                else if (messageInt == 9)
                {
                    processed = true;

                    currentInput += 9;
                    updateDisplay();
                    if (!doubleD)
                    {
                        operationAmount++;
                        doubleD = true;
                    }
                    doubleOpp = false;
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
        #region Numbers
        if (Input.GetKeyDown("0"))
        {
            currentInput += 0;
            updateDisplay();
            if (!doubleD)
            {
                operationAmount++;
                doubleD = true;
            }
            doubleOpp = false;
        }
        #endregion
        #region Opperations
        else if (Input.GetKeyDown("q")) //Add
        {
            if (!doubleOpp)
            {
                currentInput += "+";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }

        else if (Input.GetKeyDown("w")) //Sub
        {
            if (!doubleOpp)
            {
                currentInput += "-";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }
        else if (Input.GetKeyDown("e")) //Multiply
        {
            if (!doubleOpp)
            {
                currentInput += "*";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }
        else if (Input.GetKeyDown("r")) //Divide
        {
            if (!doubleOpp)
            {
                currentInput += "/";
                updateDisplay();
                operationAmount++;
                doubleD = false;
                doubleOpp = true;
            }
        }
        #endregion
        #region Other
        else if (Input.GetKeyDown("a")) //equal
        {
            calcResult();
            doubleD = false;
            doubleOpp = true;

            if (operationAmount != operationReq || winCon == false || loseCon == true)
            {
                Invoke("clearInput", 1f);
            }
            else if(challenegeDone == 0 && result == endAmount) //Challenege #1 Done
            {
                challenegeNum[0].SetActive(false);
                challenegeNum[1].SetActive(true);
                challenegeDone++;
                clearInput();
            }
            else if(challenegeDone == 1 && result == endAmount && winCon == true) //Challenege #2 Done
            {
                challenegeNum[1].SetActive(false);
                challenegeNum[2].SetActive(true);
                challenegeDone++;
                clearInput();
            }
            else if (challenegeDone == 2 && result == endAmount && loseCon != true) //Challenege #3 Done
            {
                challenegeNum[2].SetActive(false);
                challenegeNum[3].SetActive(true);
                challenegeDone++;
                clearInput();
            }
            else if (challenegeDone == 3 && result == endAmount && loseCon != true) //Challenge #4 Done
            {
                congrats.SetActive(true);
            }
            else if (challenegeDone == 4 && result == endAmount && winCon == true) //Challenge #5 Done
            {
                congrats.SetActive(true);
            }
        }
        else if (Input.GetKeyDown("s")) //Clear
        {
            clearInput();
        }

        qOne.text = operationAmount.ToString();
        

        if(challenegeDone == 0 || challenegeDone == 2 || challenegeDone == 3) //Make some challenges not need the winCon
        {
            winCon = true;
        }
        #endregion
        #endregion
    }

    public void calcResult()
    {
        try
        {
            result = System.Convert.ToDouble(new System.Data.DataTable().Compute(currentInput, ""));

            currentInput = result.ToString();
            updateDisplay();
        }

        catch (System.Exception)
        {
            currentInput = "Error";
            updateDisplay();
        }
    }
    private void clearInput()
    {
        currentInput = "";
        result = 0.0;
        operationAmount = 0;
        updateDisplay();
        doubleD = false;
        doubleOpp = true;
        winCon = false;
        loseCon = false;
    }
    private void updateDisplay()
    {
        displayText.text = currentInput;
    }
}
