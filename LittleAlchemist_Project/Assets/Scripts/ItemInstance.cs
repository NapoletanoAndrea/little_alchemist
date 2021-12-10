using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour, IInteractable {
    [SerializeField] private ItemSO item;
    [SerializeField] private VoidEventChannelSO pickingUpEventChannel;
    [SerializeField] private PickedUpEventChannelSO pickedUpEventChannel;

    private void Awake() {
        pickedUpEventChannel.OnPickedUpItem += OnPickedUp;
    }

    public void OnPickedUp(ItemSO item, int amount, ItemInstance itemInstance) {
        if (itemInstance == this) {
            pickedUpEventChannel.OnPickedUpItem -= OnPickedUp;
            item.OnPickedUp(item, amount);
            Destroy(gameObject);
        }
    }

    public void Interact() {
        pickingUpEventChannel.RaiseEvent();
        StartCoroutine(PickUpCoroutine());
    }

    private IEnumerator PickUpCoroutine() {
        yield return new WaitForSeconds(.5f);
        pickedUpEventChannel.RaiseEvent(item, 1, this);
    }

    private void OnDisable() {
        pickedUpEventChannel.OnPickedUpItem -= OnPickedUp;
    }
}
