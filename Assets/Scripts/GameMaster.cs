using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Transform initialSpawnPoint;
    [SerializeField] Transform fromRoot1SpawnPoint;
    [SerializeField] Transform fromRoot2SpawnPoint;
    //[SerializeField] Transform endSpawnPoint;
    [SerializeField] static Transform currentSpawnPoint;

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

        currentSpawnPoint = initialSpawnPoint;
    }

    public static void ProgressObjectiveState()
    {
        objState++;
        print(objState);
    }

    public static Transform GetSpawnPoint() => currentSpawnPoint;

    public void UpdateSpawnPoint()
    {
        if (objState <= ObjectiveState.SECOND_DIALOGUE)
        {
            currentSpawnPoint = fromRoot1SpawnPoint;
        }
        else if (objState <= ObjectiveState.THIRD_DIALOGUE)
        {
            currentSpawnPoint = fromRoot2SpawnPoint;
        }
    }
}
