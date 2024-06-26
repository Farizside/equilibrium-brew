using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour
{
    private MapSystem _mapSystem;
    private Transform target;
    private NavMeshAgent agent;
    [SerializeField] BuildingController[] Building;

    // Start is called before the first frame update
    void Start()
    {
        _mapSystem = MapSystem.Instance;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        InitialCharPosition();
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
        yield return new WaitForSeconds(0.025f);
        Debug.Log (agent.remainingDistance);
        yield return new WaitUntil(() => agent.remainingDistance == 0);
        SceneManager.LoadScene(sceneName);
    }
}
