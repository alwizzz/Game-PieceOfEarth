using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleFade : MonoBehaviour
{
    [SerializeField] float delayDone = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        while(delayDone >= 0f)
        {
            yield return null;
            delayDone--;
        }

        gameObject.SetActive(false);
    }

    // Update is called once per frame

}
