using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwap : MonoBehaviour
{
    public int num;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene(num, LoadSceneMode.Single);
        }
    }
}
