using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    private Transform moveCam;
    private Vector3 direction;
    private Rigidbody rb;
    private Animator animator;
    private int currentAnimationState = -1;
    
    [SerializeField] private VoidEventChannelSO pickingUpEvent;
    [SerializeField] private InputReaderSO InputReader;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    
    private static readonly int State = Animator.StringToHash("State");

    private void Awake() {
        moveCam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        pickingUpEvent.OnEventRaised += PickUpPlant;
        EnableInput();
    }

    private void Update() {
        InputReader.OnMove();
        InputReader.OnActionKeyPressed();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnMove(Vector2 movement) {
        direction = moveCam.right.normalized * movement.x + moveCam.forward.normalized * movement.y;
        direction.y = 0;

        if (direction.magnitude > .1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        
        ChangeAnimationState(direction.magnitude > .1f ? 1 : 0);
    }

    private void PickUpPlant() {
        DisableInput();
        ChangeAnimationState(2);
    }

    private void ChangeAnimationState(int stateNumber) {
        if (currentAnimationState == stateNumber) {
            return;
        }
        animator.SetInteger(State, stateNumber);
        currentAnimationState = stateNumber;
    }

    public void EnableInput() {
        InputReader.movementEvent += OnMove;
    }
    
    public void DisableInput() {
        InputReader.movementEvent -= OnMove;
    }

    private void OnDisable() {
        InputReader.movementEvent -= OnMove;
        pickingUpEvent.OnEventRaised -= PickUpPlant;
    }
}
