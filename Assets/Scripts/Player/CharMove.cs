using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour
{
    private MapSystem _mapSystem;
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    [SerializeField] BuildingController[] Building;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void InitialCharPosition()
    {
        _mapSystem = MapSystem.Instance;
        for (int i = 0; i < Building.Length; i++)
        {
            BuildingController currentBuilding = Building[i];
            if (_mapSystem.currentBuilding == currentBuilding.idxBuilding)
            {
                gameObject.transform.position = currentBuilding.transform.position;
            }
        }
    }
    
    public IEnumerator ChangeSceneUntilReachTarget(Transform target, string sceneName){	
        agent.SetDestination(target.position);
        yield return new WaitForSeconds(0.025f);
        Debug.Log (agent.remainingDistance);
        yield return new WaitUntil(() => agent.remainingDistance == 0);
        Debug.Log ("ATTACK !!");
        SceneManager.LoadScene(sceneName);
    }
}
