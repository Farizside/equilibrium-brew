using System;
using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private StoryData _storyData;
    [SerializeField] private StoryData.Story _curStory;
    [SerializeField] private int _idxStory = 0;
    
    private TimeManager _time;
    private DialogueManager _dialogue;
    
    public static StoryManager Instance;
    private void Awake()
    {
        if (Instance != null) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _time = TimeManager.Instance;
        _dialogue = DialogueManager.Instance;
        
        _curStory = _storyData._story[_idxStory];
        StartStory();
    }

    private void OnEnable()
    {
        TimeManager.OnTimeChanged += UpdateStory;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeChanged -= UpdateStory;
    }

    private void UpdateStory()
    {
        _idxStory += 1;
        try
        {
            _curStory = _storyData._story[_idxStory];
            StartStory();
        }
        catch(IndexOutOfRangeException ex)
        {
            Debug.Log("Story Selesai");
        }
        
    }

    private void StartStory()
    {
        if (_curStory.IsFinished) return;
        _dialogue.StartDialogue(_curStory.Dialogue);
        _curStory.IsFinished = true;
    }
}
