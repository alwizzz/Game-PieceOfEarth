using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private void Awake()
    {
        SingletonBehaviour();
    }

    void SingletonBehaviour()
    {
        var thisScriptCount = FindObjectsOfType<Singleton>().Length;
        if(thisScriptCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
