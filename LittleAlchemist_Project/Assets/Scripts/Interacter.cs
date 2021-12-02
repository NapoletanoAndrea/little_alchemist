using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour {
    [SerializeField] private VoidEventChannelSO OnPickedUpEventChannel;
    private IInteractable interactable;
    private float radius;

    private void Awake() {
        OnPickedUpEventChannel.OnEventRaised += SearchForInteractable;
        radius = GetComponent<SphereCollider>().radius;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            interactable?.Interact();
        }
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
}
