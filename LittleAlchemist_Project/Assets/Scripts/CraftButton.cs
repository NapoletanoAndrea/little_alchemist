using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour {
    [SerializeField] private Cauldron cauldron;

    private void OnMouseDown() {
        cauldron.Craft();
    }
}
