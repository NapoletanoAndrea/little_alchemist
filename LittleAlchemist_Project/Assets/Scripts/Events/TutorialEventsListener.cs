using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEventsListener : MonoBehaviour {
    [Header("Event Channels")]
    [SerializeField] private InputReaderSO inputReader;
    [SerializeField] private PickedUpEventChannelSO pickedUpEventChannel;
    [SerializeField] private VoidEventChannelSO triggerEventChannel;
    [SerializeField] private VoidEventChannelSO boardInteractChannel;
    [SerializeField] private VoidEventChannelSO boardExitChannel;
    [SerializeField] private VoidEventChannelSO explorationCompleteChannel;

    [Header("Texts")]
    [SerializeField] private GameObject movementText;
    [SerializeField] private GameObject pickUpItemText;
    [SerializeField] private GameObject boardInteractText;
    [SerializeField] private GameObject taskText;
    [SerializeField] private GameObject finishText;

    private GameObject activeText;

    private void Awake() {
        inputReader.movementEvent += OnMoved;
        movementText.SetActive(true);
        activeText = movementText;
        explorationCompleteChannel.OnEventRaised += OnCompletedExploration;
    }

    private void OnMoved(Vector2 movement) {
        if (movement.magnitude > .5f) {
            activeText.SetActive(false);
            pickUpItemText.SetActive(true);
            activeText = pickUpItemText;
            inputReader.movementEvent -= OnMoved;
            pickedUpEventChannel.OnPickedUp += OnPickedUpItem;
        }
    }

    private void OnPickedUpItem() {
        activeText.SetActive(false);
        pickedUpEventChannel.OnPickedUp -= OnPickedUpItem;
        triggerEventChannel.OnEventRaised += OnTriggerCollider;
    }

    private void OnTriggerCollider() {
        boardInteractText.SetActive(true);
        activeText = boardInteractText;
        triggerEventChannel.OnEventRaised -= OnTriggerCollider;
        boardInteractChannel.OnEventRaised += OnBoardInteract;
    }

    private void OnBoardInteract() {
        activeText.SetActive(false);
        taskText.SetActive(true);
        activeText = taskText;
        boardInteractChannel.OnEventRaised -= OnBoardInteract;
        boardExitChannel.OnEventRaised += OnBoardExit;
    }

    private void OnBoardExit() {
        activeText.SetActive(false);
        boardExitChannel.OnEventRaised -= OnBoardExit;
    }

    private void OnCompletedExploration() {
        activeText.SetActive(false);
        finishText.SetActive(true);
        activeText = finishText;
    }

    private void OnDisable() {
        inputReader.movementEvent -= OnMoved;
        pickedUpEventChannel.OnPickedUp -= OnPickedUpItem;
        triggerEventChannel.OnEventRaised -= OnTriggerCollider;
        boardInteractChannel.OnEventRaised -= OnBoardInteract;
        boardExitChannel.OnEventRaised -= OnBoardExit;
        explorationCompleteChannel.OnEventRaised -= OnCompletedExploration;
    }
}
