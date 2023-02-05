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
        FINISH
    }

    [SerializeField] public static ObjectiveState objState = ObjectiveState.FIRST_DIALOGUE;

    private void Awake()
    {
        SingletonBehaviour();


        //objState = ObjectiveState.FIRST_DIALOGUE;
        //DontDestroyOnLoad(this);

        print("on awake: " + objState);

        //currentSpawnPoint = initialSpawnPoint;
    }

    void SingletonBehaviour()
    {
        var thisScriptCount = FindObjectsOfType<GameMaster>().Length;
        if (thisScriptCount > 1)
        {
            print("theres exist multiple");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            print("the only one");
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void ProgressObjectiveState()
    {
        objState++;
        print(objState);

        if(objState == ObjectiveState.THIRD_DIALOGUE)
        {
            FindObjectOfType<AudioManager>().PlayEndSoundtrack();
        }
    }



}
