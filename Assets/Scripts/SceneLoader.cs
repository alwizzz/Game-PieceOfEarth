using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] static GameMaster gameMaster;

    private void Awake()
    {
        gameMaster = null;
        while(gameMaster == null)
        {
            gameMaster = FindObjectOfType<GameMaster>();
            print("finding GameMaster...");
        }
    }
    public static void LoadMainScene()
    {
        gameMaster.UpdateSpawnPoint();
        SceneManager.LoadScene("MainScene");
    }
}
