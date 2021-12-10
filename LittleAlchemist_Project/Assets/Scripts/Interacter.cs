using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour {
    [SerializeField] private InputReaderSO inputReader;
    [SerializeField] private PickedUpEventChannelSO pickedUpEventChannel;
    private IInteractable interactable;
    private float radius;

    private void Awake() {
        inputReader.actionEvent += Interact;
        pickedUpEventChannel.OnPickedUp += SearchForInteractable;
        radius = GetComponent<SphereCollider>().radius;
    }

    private void Interact() {
        interactable?.Interact();
    }

    private void SearchForInteractable() {
        Collider[] results = new Collider[] { };
        var size = Physics.OverlapSphereNonAlloc(transform.position, radius, results, LayerMask.NameToLayer("Item"));
        for (int i = 0; i < size; i++) {
            var temp = results[0].GetComponent<IInteractable>();
            if (temp != null) {
                interactable = temp;
                return;
            }
        }
        interactable = null;
    }

    private void OnTriggerEnter(Collider other) {
        var temp = other.GetComponent<IInteractable>();
        if (temp != null) {
            interactable = temp;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<IInteractable>() == interactable) {
            interactable = null;
        }
    }

    public void EnableInput() {
        inputReader.actionEvent += Interact;
    }

    public void DisableInput() {
        inputReader.actionEvent -= Interact;
    }

    private void OnDisable() {
        inputReader.actionEvent -= Interact;
        pickedUpEventChannel.OnPickedUp -= SearchForInteractable; 
    }
}
