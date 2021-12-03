using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour, IInteractable {
    [SerializeField] private ItemSO item;
    [SerializeField] private VoidEventChannelSO pickingUpEventChannel;
    [SerializeField] private VoidEventChannelSO pickedUpEventChannel;

    private void Awake() {
        pickedUpEventChannel.OnEventRaised += OnPickedUp;
    }

    public void OnPickedUp() {
        item.OnPickedUp();
        Destroy(gameObject);
    }

    public void Interact() {
        pickingUpEventChannel.RaiseEvent();
    }
}
