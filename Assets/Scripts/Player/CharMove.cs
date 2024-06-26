using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour
{
    private MapSystem _mapSystem;
    private Animator _animator;
    private Transform target;
    private NavMeshAgent agent;
    [SerializeField] BuildingController[] Building;

    private StoryManager _storyManager;

    // Start is called before the first frame update
    void Start()
    {
        _mapSystem = MapSystem.Instance;
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        InitialCharPosition();
        _storyManager = StoryManager.Instance;
    }

    void InitialCharPosition()
    {
        if (_mapSystem == null)
        {
            Debug.LogError("MapSystem instance not found");
            return;
        }

        foreach (var currentBuilding in Building)
        {   
            
            if (_mapSystem.currentBuilding == currentBuilding.idxBuilding)
            {
                Debug.Log("Setting initial position to building index: " + currentBuilding.idxBuilding);
                agent.Warp(currentBuilding.transform.position); 
                break;
            }
        }
    }
    
    public IEnumerator ChangeSceneUntilReachTarget(Transform target, string sceneName){	
        agent.SetDestination(target.position);
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            Vector3 velocity = agent.velocity;
            if (velocity.x != 0 || velocity.y != 0)
            {
                _animator.SetFloat("X", velocity.x);
                _animator.SetFloat("Y", velocity.y);
                _animator.SetBool("isWalking",true);
            }
             if (_storyManager.IdxStory == 2)
            {
                _storyManager.UpdateStory();
            }
            else if (_storyManager.IdxStory == 3)
            {
                _storyManager.UpdateStory();
            }
            yield return null;
        }
        _animator.SetBool("isWalking",false);
        SceneManager.LoadScene(sceneName);
    }
}
