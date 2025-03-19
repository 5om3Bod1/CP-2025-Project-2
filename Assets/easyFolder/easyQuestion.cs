using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class easyQuestion : MonoBehaviour
{
    public int selectVersion;
    public int selectNum;
    public int multiDiv;

    public int[] number;

    public TMP_Text equationString;
    public static easyQuestion Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        scramble();
    }
    public void scramble()
    {
        Debug.Log("Next Question");
        selectVersion = Random.Range(0, 1 + 1);
        selectNum = Random.Range(0, 3 + 1);
        number[0] = Random.Range(0, 10 + 1);
        number[1] = Random.Range(0, 10 + 1);

        if (selectVersion == 0)
        {
            deterZero();
        }
        else if(selectVersion == 1)
        {
            deterOne();
        }
    }
    
    void deterZero() //Number input; Uses endAmount;
    {
        if (selectNum == 0) //Add
        {
            equationString.text = (number[0] + " + " + " _ " + " = " + number[1]);
            easyInput.Instance.endAmount = number[1] - number[0];
        }
        else if (selectNum == 1) //Subtract
        {
            equationString.text = (number[0] + " - " + " _ " + " = " + number[1]);
            easyInput.Instance.endAmount = number[0] - number[1];
        }
        else if (selectNum == 2) //Multiply
        {
            multiDiv = Random.Range(0, 4 + 1);
            if(multiDiv == 0)
            {
                equationString.text = ("-10" + " * " + " _ " + " = " + "20");
                easyInput.Instance.endAmount = -2;
            }
            else if(multiDiv == 1)
            {
                equationString.text = ("3" + " * " + " _ " + " = " + "3");
                easyInput.Instance.endAmount = 1;
            }
            else if (multiDiv == 2)
            {
                equationString.text = ("-6" + " * " + " _ " + " = " + "24");
                easyInput.Instance.endAmount = -4;
            }
            else if (multiDiv == 3)
            {
                equationString.text = ("2" + " * " + " _ " + " = " + "36");
                easyInput.Instance.endAmount = 18;
            }
            else if (multiDiv == 4)
            {
                equationString.text = ("27" + " * " + " _ " + " = " + "0");
                easyInput.Instance.endAmount = 0;
            }
        }
        else if (selectNum == 3) //Divide
        {
            multiDiv = Random.Range(0, 4 + 1);
            if (multiDiv == 0)
            {
                equationString.text = ("16" + " / " + " _ " + " = " + "-4");
                easyInput.Instance.endAmount = -4;
            }
            else if (multiDiv == 1)
            {
                equationString.text = ("27" + " / " + " _ " + " = " + "3");
                easyInput.Instance.endAmount = 9;
            }
            else if (multiDiv == 2)
            {
                equationString.text = ("32" + " / " + " _ " + " = " + "2");
                easyInput.Instance.endAmount = 16;
            }
            else if (multiDiv == 3)
            {
                equationString.text = ("-35" + " / " + " _ " + " = " + "7");
                easyInput.Instance.endAmount = -5;
            }
            else if (multiDiv == 4)
            {
                equationString.text = ("18" + " / " + " _ " + " = " + "6");
                easyInput.Instance.endAmount = 3;
            }
        }
    }
    void deterOne() //Opperation Input; Uses conNum
    {
        if (selectNum == 0) //Add
        {
            number[2] = number[1] - number[0];
            equationString.text = (number[0] + " _ " + number[2] + " = " + number[1]);
            easyInput.Instance.conNum = "+";
        }
        else if (selectNum == 1) //Subtract
        {
            number[2] =  number[0] - number[1];
            equationString.text = (number[0] + " _ " + number[2] + " = " + number[1]);
            easyInput.Instance.conNum = "-";
        }
        else if (selectNum == 2) //Multiply
        {
            multiDiv = Random.Range(0, 4 + 1);
            if (multiDiv == 0)
            {
                equationString.text = ("-5" + " _ " + " 5 " + " = " + "-25");
            }
            else if (multiDiv == 1)
            {
                equationString.text = ("4" + " _ " + " 3 " + " = " + "12");
            }
            else if (multiDiv == 2)
            {
                equationString.text = ("17" + " _ " + " 2 " + " = " + "34");
            }
            else if (multiDiv == 3)
            {
                equationString.text = ("-10" + " _ " + " -3 " + " = " + "30");
            }
            else if (multiDiv == 4)
            {
                equationString.text = ("4" + " _ " + " -6 " + " = " + "-24");
            }
            easyInput.Instance.conNum = "*";
        }
        else if (selectNum == 3) //Divide
        {
            multiDiv = Random.Range(0, 4 + 1);
            if (multiDiv == 0)
            {
                equationString.text = ("12" + " _ " + " -4 " + " = " + "-3");
            }
            else if (multiDiv == 1)
            {
                equationString.text = ("16" + " _ " + " 2 " + " = " + "8");
            }
            else if (multiDiv == 2)
            {
                equationString.text = ("64" + " _ " + " 16 " + " = " + "4");
            }
            else if (multiDiv == 3)
            {
                equationString.text = ("-32" + " _ " + " -2 " + " = " + "16");
            }
            else if (multiDiv == 4)
            {
                equationString.text = ("9" + " _ " + " -3 " + " = " + "-3");
            }
            easyInput.Instance.conNum = "/";
        }
    }

}
