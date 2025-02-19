using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challengeFour : MonoBehaviour
{
    //Can't subtract or multiply and 9 inputs

    public int startNum;
    public int endNum;
    private void Start()
    {
        calcScript.Instance.operationAmount = 0;
        calcScript.Instance.operationReq = 9;
        startNum = Random.Range(0, 10);
        endNum = Random.Range(0, 10);

        calcScript.Instance.start.text = startNum.ToString();
        calcScript.Instance.end.text = endNum.ToString();
        calcScript.Instance.startAmount = startNum;
        calcScript.Instance.endAmount = endNum;
    }
    void Update()
    {
        if (Input.GetKeyDown("w")) //Subtract
        {
            calcScript.Instance.loseCon = true;
            Debug.Log("Complete");
        }
        else if (Input.GetKeyDown("e")) //Multiply
        {
            calcScript.Instance.loseCon = true;
            Debug.Log("Complete");
        }
    }
}
