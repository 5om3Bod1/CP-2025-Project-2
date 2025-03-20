using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mediumQuestion : MonoBehaviour
{
    public int selectVersion;
    public int selectNum;
    public int multiDiv;

    public TMP_Text equationString;

    public TMP_Text playerString0;
    public TMP_Text playerString1;
    public string answerZ;
    public string answerO;

    public int zeroNum;
    public int oneNum;
    public string[] whichOpp;
    
    public int[] number;

    public int endAmount;

    private string currentInput = "";

    public int valNum;

    public GameObject[] inputObj;

    public static mediumQuestion Instance { get; private set; }

    void Start()
    {
        Instance = this;
        scramble();
    }
    private void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            scramble();
        }
        else if (Input.GetKeyDown("t"))
        {
            Debug.Log(answerZ);
            Debug.Log(answerO);
        }
    }
    public void scramble()
    {
        Debug.Log("Next Question");
        //selectVersion = Random.Range(0, 1 + 1);
        //selectNum = Random.Range(0, 11 + 1);
        selectVersion = 0;
        if (selectVersion == 0)
        {
            deterZero();
        }
        else if (selectVersion == 1)
        {
            deterOne();
        }
    }

    void deterZero() //Number input;
    {
        number[0] = Random.Range(1, 10 + 1);
        number[1] = Random.Range(1, 10 + 1);
        zeroNum = Random.Range(0, 3 + 1);
        oneNum = Random.Range(0, 3 + 1);
        while (oneNum == zeroNum) //Prevents repeat opperations
        {
            Debug.Log("Rerolled");
            oneNum = Random.Range(0, 3 + 1);
        }
        equationString.text = (number[0] + " " + whichOpp[zeroNum] + "  __  " + whichOpp[oneNum] + "  __  " + "= " + number[1]);
    }
    void deterOne() //Opperation Input; Uses conNum
    {
        equationString.text = (number[0] + "  _  " + whichOpp[zeroNum] + "  _  " + whichOpp[oneNum] + " = " + number[1]);
    }
    void endCondition() //When player submits final answer
    {
        currentInput += number[0];
        currentInput += whichOpp[zeroNum];
        currentInput += answerZ;
        currentInput += whichOpp[oneNum];
        currentInput += answerO;
        calcEnd();
    }
    void winCheck()
    {
       if(endAmount == number[1])
       {
            reset();
            scramble();
       }
       else
       {
            reset();
            Debug.Log("Wrong");
       }
    }
    public void calcEnd()
    {
        try
        {
            endAmount = System.Convert.ToInt32(new System.Data.DataTable().Compute(currentInput, ""));
            winCheck();
        }

        catch (System.Exception)
        {
            currentInput = "Error";
        }
    }
    public void valCheck()
    {
        if (valNum == 0)
        {
            inputObj[0].SetActive(true);
            inputObj[1].SetActive(false);
        }
        else if(valNum == 2)
        {
            inputObj[0].SetActive(false);
            inputObj[1].SetActive(true);
        }
        else if(valNum == 3)
        {
            endCondition(); //Checks answers
        }
    }
    void reset()
    {
        updateInfo();
        currentInput = "";
        answerZ = "";
        answerO = "";
        playerString0.text = answerZ;
        playerString1.text = answerO;
        valNum = 0;
        valCheck();
    }
    void updateInfo()
    {
        medInput0.Instance.currentInput = "";
        medInput1.Instance.currentInput = "";
    }
}
