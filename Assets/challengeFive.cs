using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challengeFive : MonoBehaviour
{
    //Must use 13 and 7 inputs

    public int startNum;
    public int endNum;

    public bool conOne;
    public bool conTwo;

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
        if (Input.anyKey)
        {
            if (Input.GetKeyUp("1"))
            {
                conOne = true;
            }
            else if (Input.GetKeyUp("3") && conOne == true)
            {
                conTwo = true;
            }
            else
            {

            }
        }
        
        if (conOne && conTwo == true)
        {
            calcScript.Instance.winCon = true;
        }
    }
}
