using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip mainSoundtrack;
    [SerializeField] AudioClip endSoundtrack;
    [SerializeField] AudioClip pickupSFX;

    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        SingletonBehaviour();
    }
    void SingletonBehaviour()
    {
        var thisScriptCount = FindObjectsOfType<AudioManager>().Length;
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

    public void PlayMainSoundtrack()
    {
        if (audioSource.isPlaying) { audioSource.Stop(); }
        audioSource.clip = mainSoundtrack;
        audioSource.Play();
    }

    public void PlayEndSoundtrack()
    {
        if (audioSource.isPlaying) { audioSource.Stop(); }
        audioSource.clip = endSoundtrack;
        audioSource.Play();
    }

    public void PlayPickupSFX()
    {
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
    }

}
