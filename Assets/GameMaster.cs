using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public enum ObjectiveState
    {
        FIRST_DIALOGUE,
        FIRST_ROOT, // cabut benalu
        SECOND_DIALOGUE,
        SECOND_ROOT, // buang sampah
        THIRD_DIALOGUE,
        PARENT_TREE
    }

    public static ObjectiveState objState;

    private void Awake()
    {
        objState = ObjectiveState.FIRST_DIALOGUE;
        DontDestroyOnLoad(this);

        print(objState);
    }

    public static void ProgressObjectiveState()
    {
        objState++;
        print(objState);
    }
}
