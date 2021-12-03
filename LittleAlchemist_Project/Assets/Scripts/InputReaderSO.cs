using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Input Reader")]
public class InputReaderSO : ScriptableObject {
    [SerializeField] private string horizontalAxisString;
    [SerializeField] private string verticalAxisString;
    [SerializeField] private KeyCode actionKey;
    [SerializeField] private KeyCode inventoryKey;

    public UnityAction<Vector2> movementEvent;
    public UnityAction actionEvent;
    public UnityAction inventoryEvent;

    public void OnMove() {
        movementEvent?.Invoke(new Vector2(Input.GetAxisRaw(horizontalAxisString), Input.GetAxisRaw(verticalAxisString)));
    }

    public void OnActionKeyPressed() {
        if (Input.GetKeyDown(actionKey)) {
            actionEvent?.Invoke();
        }
    }

    public void OnInventoryKeyPressed() {
        if (Input.GetKeyDown(inventoryKey)) {
            inventoryEvent?.Invoke();
        }
    }
}
