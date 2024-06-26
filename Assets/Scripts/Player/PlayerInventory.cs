using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private TMP_Text _currentRecipe;

    public void UseStock(string key, int value)
    {
        for (int i = 0; i < _inventoryData._stocks.Length; i++)
        {
            if (_inventoryData._stocks[i].key == key)
            {
                _inventoryData._stocks[i].value -= value;
            }
        }
    }
    
    public void BuyStock(string key, int value, int price)
    {
        for (int i = 0; i < _inventoryData._stocks.Length; i++)
        {
            if (_inventoryData._stocks[i].key == key)
            {
                _inventoryData._stocks[i].value += value;
                _inventoryData._money -= _inventoryData._stocks[i].price;
            }
        }
    }

    public void UseOneStock(string key)
    {
        for (int i = 0; i < _inventoryData._stocks.Length; i++)
        {
            if (_inventoryData._stocks[i].key == key)
            {
                _inventoryData._stocks[i].value -= 1;
            }
        }

        _currentRecipe.text += " " + key;
    }
    
    public void UseMedicine(string key, int value)
    {
        for (int i = 0; i < _inventoryData._medicines.Length; i++)
        {
            if (_inventoryData._medicines[i].key == key)
            {
                _inventoryData._medicines[i].value -= value;
            }
        }
    }
    
    public void BuyMedicine(string key, int value, int price)
    {
        for (int i = 0; i < _inventoryData._medicines.Length; i++)
        {
            if (_inventoryData._medicines[i].key == key)
            {
                _inventoryData._medicines[i].value += value;
                _inventoryData._money -= _inventoryData._medicines[i].price;
            }
        }
    }

    public void Brew()
    {
        DialogueManager.Instance.teaCanvas.SetActive(false);
    }
}
