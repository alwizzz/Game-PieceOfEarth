using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatTree : Interactable
{
    string firstDialogue = "first";
    string secondDialogue = "second";
    string thirdDialogue = "third";

    public void Talk()
    {
        var objState = GameMaster.objState;
        if(objState >= GameMaster.ObjectiveState.FIRST_DIALOGUE)
        {
            print(firstDialogue);
        } else if(objState >= GameMaster.ObjectiveState.SECOND_DIALOGUE)
        {
            print(secondDialogue);
        }
        else if (objState >= GameMaster.ObjectiveState.THIRD_DIALOGUE)
        {
            print(thirdDialogue);
        }

        GameMaster.ProgressObjectiveState();
    }
}
