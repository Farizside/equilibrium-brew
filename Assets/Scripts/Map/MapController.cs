using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private MapSystem _mapSystem;
    [SerializeField] GameObject Char;
    [SerializeField] BuildingController[] Building;

    // Start is called before the first frame update
    void Start()
    {
        _mapSystem = MapSystem.Instance;
        for (int i = 0; i < Building.Length; i++)
        {
            BuildingController currentBuilding = Building[i];
            if (_mapSystem.currentBuilding == currentBuilding.idxBuilding)
            {
                Char.transform.position = currentBuilding.transform.position;
            }
        }
    }
}
