using System;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [NonSerialized] public Image image;
    private Animator _animator;
    public int id;

    private void Start()
    {
        _animator = GetComponent<Animator>();
         image = GetComponent<Image>();
    }

    private void OnMouseDown()
    {
        image.raycastTarget = false;
        _animator.SetBool("ItemDeleted", true);
        FindObjectOfType<Inventory>().AddItem(this);
    }
}
