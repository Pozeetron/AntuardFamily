using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] inventory = new Item[7];
    [SerializeField] private Transform[] slots;

    public int deletedCouple;

    private void Start()
    {
        deletedCouple = 0;
    }

    public void AddItem(Item item)
    {
        if(IsInventoryFull())
            return;
        
        bool canAdd = true;
        
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null && canAdd)
            {
                inventory[i] = item;
                item.gameObject.GetComponent<Animator>().SetBool("ItemDeleted", false);
                item.gameObject.GetComponent<Animator>().SetBool("ItemAdded", true);
                item.transform.position = slots[i].position;
                canAdd = false;
            }
            else if (inventory[i]?.id == item.id)
            {
                int j = 0;
                for (; j < inventory.Length; j++)
                {
                    if (inventory[j] == null)
                    {
                        inventory[j] = item;
                        item.transform.position = slots[j].position;
                        break;
                    }
                }
                item.gameObject.GetComponent<Animator>().SetBool("ItemAdded", false);
                inventory[i].gameObject.GetComponent<Animator>().SetBool("ItemAdded", false);
                item.gameObject.GetComponent<Animator>().SetBool("ItemDeleted", true);
                inventory[i].gameObject.GetComponent<Animator>().SetBool("ItemDeleted", true);
                Destroy(item.gameObject, 1f);
                Destroy(inventory[i].gameObject, 1f);
                deletedCouple++;
                inventory[i] = null;
                inventory[j] = null;
                break;
            }
        }

        canAdd = true;
    }

    public bool IsInventoryFull()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                return false;
            }
        }
        
        return true;
    }
    
    private bool IsInventoryEmpty()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                return true;
            }
        }
        
        return false;
    }

    private void Vibrate()
    {
        if (PlayerPrefs.GetInt("vibrationOn") == 1)
        {
            Debug.Log("Vibrate");
            Handheld.Vibrate();
        }
    }
}
