using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    [SerializeField] static int collectableCount = 0;

    public void Collect()
    {
        collectableCount++;
        print("collectableCount: " + collectableCount);
        Destroy(gameObject);
    }
}
