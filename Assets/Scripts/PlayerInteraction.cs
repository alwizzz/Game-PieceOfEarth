using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] bool isTouching;
    [SerializeField] Interactable touchedInteractable;
    [SerializeField] PlayerAction playerAction;

    private void Start()
    {
        isTouching = false;
        touchedInteractable = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            print("hoy");
            isTouching = true;
            touchedInteractable = other.gameObject.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            isTouching = false;
            touchedInteractable = null;
        }
    }

    public bool IsTouching() => isTouching;
    public Interactable GetTouchedInteractable() => touchedInteractable;

    public void SetIsTouching(bool value) { isTouching = value; }
    public void SetNullTouchedInteractable() { touchedInteractable = null; } //TODO: bad implementation
}
