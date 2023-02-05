using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarper : MonoBehaviour
{
    //[SerializeField] bool updateSpawnPoint = false;

    [SerializeField] private GameMaster.ObjectiveState requiredObjState;
    [SerializeField] string targetScene;

    private void Start()
    {
        //print(requiredObjState);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" )
        {
            if(GameMaster.objState == requiredObjState)
            {
                print("warp with objective: " + requiredObjState);
                //if (updateSpawnPoint) { FindObjectOfType<GameMaster>().UpdateSpawnPoint(); }

                SceneLoader.LoadScene(targetScene);
            } else
            {
                print("attempt to wrap with invalid objective state; " + requiredObjState);
            }
        }
    }
}
