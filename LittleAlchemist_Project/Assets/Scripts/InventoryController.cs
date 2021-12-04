using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    private Inventory inventory = new Inventory();

    [SerializeField] private PickedUpEventChannelSO pickedUpEventChannel;

    private void Awake() {
        pickedUpEventChannel.OnPickedUpItem += inventory.Add;
    }
}
