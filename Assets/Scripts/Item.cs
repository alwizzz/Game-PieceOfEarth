using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField] Transform itemGroup;
    int itemCount = 0;
    static int maxItem = 0;

    [SerializeField] private string codeName;
    public void MoveToPivot(Transform pivotObject)
    {
        transform.parent = pivotObject;
        transform.position = pivotObject.position;
    }


    //public void HideTo(Transform obj)
    //{
    //    gameObject.SetActive(false);
    //    transform.parent = obj;
    //}
    private void Start()
    {
        FindObjectOfType<Receiver>().IncrementMaxItem();
        maxItem++;
    }

    public string GetCodeName() => codeName;

    public void Drop()
    {
        GetComponent<Collider>().enabled = true;
        transform.parent = itemGroup;
        transform.position = new Vector3(transform.position.x, itemGroup.position.y, transform.position.z);

        itemCount++;
        if(itemCount >= maxItem)
        {
            GameMaster.ProgressObjectiveState(); // go to THIRD_DIALOGUE state
        }
    }

}
