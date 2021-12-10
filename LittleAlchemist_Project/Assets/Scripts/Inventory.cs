using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Inventory {
    public Action Changed;
    public List<ItemStack> items = new List<ItemStack>();

    public void Add(ItemSO item, int count, ItemInstance itemInstance) {
        if (count <= 0) {
            return;
        }

        for (int i = 0; i < items.Count; i++) {
            ItemStack stack = items[i];
            if (stack.item == item) {
                stack.amount += count;
                return;
            }
        }
        items.Add(new ItemStack(item, count));
        Changed.Invoke();
        Debug.Log(items[items.Count-1].item.itemName);
    }
}
