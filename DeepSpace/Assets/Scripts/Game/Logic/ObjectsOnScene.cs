using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectsOnScene : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents._Boss_Apperaring += DestroyAllRobotSoldiersOnScene;
    }

    public void DestroyAllRobotSoldiersOnScene()
    {
        RobotSoldier[] _robots = FindObjectsOfType<RobotSoldier>();

        for (int i = 0; i < _robots.Length; i++)
            Destroy(_robots[i].gameObject);
    }
    
    private void OnDisable()
    {
        GameEvents._Boss_Apperaring -= DestroyAllRobotSoldiersOnScene;
    }
}