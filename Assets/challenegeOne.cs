using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenegeOne : MonoBehaviour
{
    //Anything goes and 5 inputs

    public int startNum;
    public int endNum;
    private void Start()
    {
        calcScript.Instance.operationAmount = 0;
        calcScript.Instance.operationReq = 5;
        startNum = Random.Range(0, 10);
        endNum = Random.Range(0, 10);

        calcScript.Instance.start.text = startNum.ToString();
        calcScript.Instance.end.text = endNum.ToString();
        calcScript.Instance.startAmount = startNum;
        calcScript.Instance.endAmount = endNum;
    }
}
