using System;
using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;

[CreateAssetMenu]
public class StoryData : ScriptableObject
{
    [SerializeField] public Story[] _story;
    
    [Serializable]
    public struct Story
    {
        public int Day;
        public TimeManager.Time Time;
        public bool IsFinished;
        public DialogNodeGraph Dialogue;
    }
}
