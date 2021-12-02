using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    private Transform moveCam;
    private Vector3 direction;
    private Rigidbody rb;
    private Animator animator;
    
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    
    private static readonly int Running = Animator.StringToHash("Running");

    private void Awake() {
        moveCam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        direction = moveCam.forward.normalized * Input.GetAxisRaw("Vertical") + moveCam.right.normalized * Input.GetAxisRaw("Horizontal");
        direction.y = 0;

        if (direction.magnitude > .1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        animator.SetBool(Running, direction.magnitude > .1f);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
