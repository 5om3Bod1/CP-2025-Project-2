using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenegeThree : MonoBehaviour
{
    //Can't add or divide and 9 inputs

    public int startNum;
    public int endNum;
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
        if (Input.GetKeyDown("q")) //Add
        {
            calcScript.Instance.loseCon = true;
            Debug.Log("Complete");
        }
        else if (Input.GetKeyDown("r")) //Divide
        {
            calcScript.Instance.loseCon = true;
            Debug.Log("Complete");
        }
    }
}
