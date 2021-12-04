using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    private Inventory inventory = new Inventory();

    [SerializeField] private InventoryEventChannelSO inventoryEventChannel;
    [SerializeField] private PickedUpEventChannelSO pickedUpEventChannel;

    private void Awake() {
        inventory.Changed += () => { inventoryEventChannel.RaiseEvent(inventory); };
        pickedUpEventChannel.OnPickedUpItem += inventory.Add;
    }

    private void Start() {
        UIInventory.Instance.SetInventory(inventory);
    }

    private void OnDisable() {
        pickedUpEventChannel.OnPickedUpItem -= inventory.Add;
    }
}
