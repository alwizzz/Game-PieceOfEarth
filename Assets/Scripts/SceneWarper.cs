using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWarper : MonoBehaviour
{
    [SerializeField] private GameMaster.ObjectiveState requiredObjState;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" )
        {
            if(GameMaster.objState == requiredObjState)
            {
                print("warp with objective: " + requiredObjState);
            } else
            {
                print("attempt to wrap with invalid objective state");
            }
        }
    }
}
