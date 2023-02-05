using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatTree : Interactable
{
    [SerializeField] bool hasExhaustedDialogues;
    [SerializeField] bool isTalking;
    [SerializeField] List<string> currentDialogues;
    [SerializeField] int dialogueIndex;

    [SerializeField] DialoguePanel dialoguePanel;

    [SerializeField] PlayerMovement playerMovement;

    List<string> firstDialogues = new List<string>
    { 
        "O, pain...",
        "O, great pain...",
        "One's body can't stop this withering",
        "Oh, one's poor rootlings"

    };
    List<string> secondDialogues = new List<string>
    {
        "One's pain.. it's been lifted slightly",
        "One's mind starts to recollect",
        "One's rootlings.. they need one's aid..",
    };
    List<string> thirdDialogues = new List<string>
    {
        "...",
        "......",
        "...........",
    };

    private void Start()
    {
        Setup();
    }

    void Setup()
    {
        this.playerMovement = null;

        hasExhaustedDialogues = false;
        isTalking = false;
        dialogueIndex = 0;

        var objState = GameMaster.objState;
        if (objState >= GameMaster.ObjectiveState.THIRD_DIALOGUE)
        {
            currentDialogues = thirdDialogues;
        }
        else if (objState >= GameMaster.ObjectiveState.SECOND_DIALOGUE)
        {
            currentDialogues = secondDialogues;
        }
        else if (objState >= GameMaster.ObjectiveState.FIRST_DIALOGUE)
        {
            currentDialogues = firstDialogues;
        }
    }

    private void Update()
    {
        if(isTalking && Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    public void Talk(PlayerMovement playerMovement)
    {
        if(this.playerMovement == null) { this.playerMovement = playerMovement; }

        if(isTalking)
        {
            print("attempt to Talk when its already in isTalking state");
            return;
        }
        EnterDialogueMode();
    }

    void EnterDialogueMode()
    {
        playerMovement.SetIsAbleToMove(false);

        print("enter dialogue mode");
        isTalking = true;

        dialoguePanel.SetText(
            currentDialogues
            [
                dialogueIndex >= currentDialogues.Count 
                ? 
                currentDialogues.Count - 1 
                : 
                dialogueIndex
            ]
        );
        dialoguePanel.ShowPanel(true);
        //NextDialogue();
    }

    void NextDialogue()
    {
        dialogueIndex++;
        if(dialogueIndex >= currentDialogues.Count)
        {
            dialoguePanel.SetText(currentDialogues[currentDialogues.Count - 1]);
            if(!hasExhaustedDialogues)
            {
                hasExhaustedDialogues = true;
                GameMaster.ProgressObjectiveState();
            }

            ExitDialogueMode();
            return;
        }

        dialoguePanel.SetText(currentDialogues[dialogueIndex]);

    }

    void ExitDialogueMode()
    {
        print("exit dialogue mode");
        playerMovement.SetIsAbleToMove(true);

        isTalking = false;
        dialoguePanel.ShowPanel(false);
    }
}
