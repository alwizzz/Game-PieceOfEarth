using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInteraction playerInteraction;

    [SerializeField] Animator playerAnimator;

    [SerializeField] bool isHolding;
    //[SerializeField] bool isUsingProcessor;

    [SerializeField] Item heldItem;
    [SerializeField] Transform holdingPivot;
    //LevelMaster levelMaster;

    private void Start()
    {
        //levelMaster = FindObjectOfType<LevelMaster>();
        UpdateIsHolding();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (playerInteraction.IsTouching())
            {
                var interactable = playerInteraction.GetTouchedInteractable();
                var type = interactable.GetType().ToString();
                if (type == "Item" && !isHolding)
                {
                    GiveItemToHold((Item)interactable);
                    FindObjectOfType<AudioManager>().PlayPickupSFX();
                } else if (type == "Collectable" && !isHolding)
                {
                    ((Collectable)interactable).Collect();
                    playerInteraction.SetIsTouching(false);
                    playerInteraction.SetNullTouchedInteractable();
                    
                } else if (type == "GreatTree" && !isHolding)
                {
                    ((GreatTree)interactable).Talk(playerMovement);
                    
                } else if(type == "Receiver" && isHolding)
                {
                    ((Receiver)interactable).TakeItemInHand(heldItem);
                    heldItem = null;
                    UpdateIsHolding();
                    
                }
            } else if (isHolding)
            {
                {
                    heldItem.Drop();
                    heldItem = null;

                }

                UpdateIsHolding();
            }
        }
        
    }

    public bool IsHolding() => isHolding;
    public Item GetHeldItem() => heldItem;
    public Item TakeHeldItem()
    {
        var temp = heldItem;
        heldItem = null;
        UpdateIsHolding();

        return temp;
    }
    public void GiveItemToHold(Item input)
    {
        heldItem = input;

        heldItem.GetComponent<Collider>().enabled = false;
        playerInteraction.SetIsTouching(false);

        heldItem.MoveToPivot(holdingPivot);
        UpdateIsHolding();
    }
    void UpdateIsHolding()
    {
        isHolding = (heldItem ? true : false);
        playerAnimator.SetBool("isHolding", isHolding);
    }

    public void HideHeldItem() { heldItem.gameObject.SetActive(false); }
    public void ShowHeldItem() { heldItem.gameObject.SetActive(true); }
    public void SetIsUsingProcessor(bool value)
    {
        //isUsingProcessor = value;
        playerMovement.SetIsAbleToMove(!value);
    }
    public PlayerMovement GetPlayerMovement() => playerMovement;

}
