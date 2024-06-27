using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private GameObject[] _images;
    [SerializeField] private Sprite _default;
    
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
        Sprite a = null;
        for (int i = 0; i < _inventoryData._stocks.Length; i++)
        {
            if (_inventoryData._stocks[i].key == key)
            {
                _inventoryData._stocks[i].value -= 1;
                a = _inventoryData._stocks[i].Image;
            }
        }

        foreach (var image in _images)
        {
            if (image.GetComponent<Image>().sprite == _default)
            {
                image.GetComponent<Image>().sprite = a;
                return;
            }
        }
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
        foreach (var image in _images)
        {
            image.GetComponent<Image>().sprite = _default;
        }
    }
}
