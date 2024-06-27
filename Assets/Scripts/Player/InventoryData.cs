using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[CreateAssetMenu]
public class InventoryData : ScriptableObject
{
    [SerializeField] public int _money;
    [SerializeField] public Stock[] _stocks;
    [SerializeField] public Medicine[] _medicines;
    
    [Serializable]
    public struct Stock
    {
        public string key;
        public Sprite Image;
        public int value;
        public int price;
    }
    
    [Serializable]
    public struct Medicine
    {
        public string key;
        public int value;
        public int price;
    }
}
