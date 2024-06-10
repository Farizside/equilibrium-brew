using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoListHandler : MonoBehaviour
{
    private StoryManager _storyManager;

    private void Start()
    {
        _storyManager = StoryManager.Instance;
    }

    public void OpenToDoList()
    {
        gameObject.SetActive(true);
    }

    public void CloseToDoList()
    {
        if (_storyManager.IdxStory == 0)
        {
            _storyManager.UpdateStory();
            _storyManager.StartStory();
        }
        
        gameObject.SetActive(false);
    }
}
