using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    [SerializeField] static bool validate;
    [SerializeField] static int collectableCount = 0;
    [SerializeField] static int maxCollectable = 0;

    private void Start()
    {
        maxCollectable++;
        //print(maxCollectable);
    }
    public void Collect()
    {
        if(validate && GameMaster.objState != GameMaster.ObjectiveState.FIRST_ROOT) 
        {
            print("attempt to do FIRST_ROOT objective when not currently in that state");
            return;
        }
        FindObjectOfType<AudioManager>().PlayPickupSFX();

        collectableCount++;
        print("collectableCount: " + collectableCount);

        if(collectableCount >= maxCollectable)
        {
            GameMaster.ProgressObjectiveState(); // go to SECOND_DIALOGUE state
        }

        Destroy(gameObject);
    }
}
