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

    public int IdxStory => _idxStory;
    
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
        // OnStoryFinished += UpdateStory;
    }

    private void OnDisable()
    {
        // OnStoryFinished -= UpdateStory;
    }

    public void UpdateStory()
    {
        _curStory.IsFinished = true;
        _idxStory += 1;
        
        try
        {
            _curStory = _storyData._story[_idxStory];
            Debug.Log("Story updated");
        }
        catch(IndexOutOfRangeException ex)
        {
            Debug.Log("Story Selesai");
        }
        
    }

    public void StartStory()
    {
        if (_curStory.IsFinished) return;
        _dialogue.StartDialogue(_curStory.Dialogue);
    }
}
