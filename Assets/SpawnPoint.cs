using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform initialSpawnPoint;
    [SerializeField] Transform fromRoot1SpawnPoint;
    [SerializeField] Transform fromRoot2SpawnPoint;
    //[SerializeField] Transform endSpawnPoint;
    [SerializeField] Transform currentSpawnPoint;

    private void Awake()
    {
        var state = GameMaster.objState;
        if(state == GameMaster.ObjectiveState.FIRST_DIALOGUE)
        {
            currentSpawnPoint = initialSpawnPoint;
        } else if (state == GameMaster.ObjectiveState.SECOND_DIALOGUE)
        {
            currentSpawnPoint = fromRoot1SpawnPoint;
        } else if (state == GameMaster.ObjectiveState.THIRD_DIALOGUE)
        {
            currentSpawnPoint = fromRoot2SpawnPoint;
        }
    }

    public Transform GetSpawnPoint() => currentSpawnPoint;

    //public void UpdateSpawnPoint()
    //{
    //    if (objState <= ObjectiveState.SECOND_DIALOGUE)
    //    {
    //        currentSpawnPoint = fromRoot1SpawnPoint;
    //    }
    //    else if (objState <= ObjectiveState.THIRD_DIALOGUE)
    //    {
    //        currentSpawnPoint = fromRoot2SpawnPoint;
    //    }
    //}

}
