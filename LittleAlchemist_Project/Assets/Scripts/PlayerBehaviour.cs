using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    IDLE,
    MENUING
}

public class PlayerBehaviour : MonoBehaviour {
    private Transform moveCam;
    private Vector3 direction;
    private Rigidbody rb;
    private Animator animator;
    private PlayerState playerState;
    private int currentAnimationState = -1;

    [SerializeField] private VoidEventChannelSO OnPickedUpEventChannel;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    
    private static readonly int State = Animator.StringToHash("State");

    private void Awake() {
        moveCam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        OnPickedUpEventChannel.OnEventRaised += PickUpPlant;
    }

    private void Update() {
        switch (playerState) {
            case PlayerState.IDLE:
                GetDirection();
                break;
            case PlayerState.MENUING:
                animator.SetInteger(State, 0);
                break;
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void GetDirection() {
        direction = moveCam.forward.normalized * Input.GetAxisRaw("Vertical") + moveCam.right.normalized * Input.GetAxisRaw("Horizontal");
        direction.y = 0;

        if (direction.magnitude > .1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            ChangeAnimationState(1);
        }
        else {
            ChangeAnimationState(0);
        }
    }

    private void PickUpPlant() {
        animator.SetInteger(State, 2);
    }

    private void ChangeAnimationState(int stateNumber) {
        if (currentAnimationState == stateNumber) {
            return;
        }
        animator.SetInteger(State, stateNumber);
        currentAnimationState = stateNumber;
    }
}
