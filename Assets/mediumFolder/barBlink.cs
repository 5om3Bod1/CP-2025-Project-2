using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barBlink : MonoBehaviour
{
    public GameObject[] bar;
    public int num;
    void Start()
    {
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        if(mediumQuestion.Instance.valNum == 0)
        {
            bar[0].SetActive(true);
            yield return new WaitForSeconds(.5f);
            bar[0].SetActive(false);
        }
        else if(mediumQuestion.Instance.valNum >= 1)
        {
            bar[1].SetActive(true);
            yield return new WaitForSeconds(.5f);
            bar[1].SetActive(false);
        }
        yield return new WaitForSeconds(.6f);
        StartCoroutine(blink());
    }
}
