using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject {
    public string itemName;
    [TextArea] public string description;
    public GameObject itemPrefab;
    public bool baseIngredient;

    public void OnPickedUp(ItemSO item, int amount) {
        Debug.Log(itemName + " has been picked up!");
    }
}

public class ItemStack {
    public ItemSO item;
    public int amount;

    public ItemStack(ItemSO item, int amount) {
        this.item = item;
        this.amount = amount;
    }
}
