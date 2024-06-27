using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoListHandler : MonoBehaviour
{
    private StoryManager _storyManager;
    public Animator _animator;

    private void Start()
    {
        _storyManager = StoryManager.Instance;
    }

    public void OpenToDoList()
    {
        _animator.gameObject.SetActive(true);
        _animator.SetTrigger("Open");
    }

    public void CloseToDoList()
    {
        StartCoroutine(WaitUntilClose());
    }
    IEnumerator WaitUntilClose()
    {
        _animator.SetTrigger("Close");
        yield return new WaitForSeconds(_animator.runtimeAnimatorController.animationClips[0].length);
        _animator.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (_storyManager.IdxStory == 0)
        {
            _storyManager.UpdateStory();
            _storyManager.StartStory();
        }
    }
    
}
