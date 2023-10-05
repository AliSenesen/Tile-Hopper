using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform cubePrefab;
    [SerializeField] private Transform startCube;

    private Transform _currentCube = null;

    private void Start()
    {
        _currentCube = startCube;
        StartCoroutine(CubeSpawnCoroutine());
    }

    private void CreateCube(Transform platform, int randomSpawnPoint)
    {
        if (randomSpawnPoint == 0)
        {
            _currentCube =
                Instantiate(cubePrefab, platform.position + Vector3.right * 2f, Quaternion.identity);
        }


        else if (randomSpawnPoint == 1)
        {
            _currentCube =
                Instantiate(cubePrefab, platform.position + Vector3.left * 2f, Quaternion.identity);
        }


        else if (randomSpawnPoint == 2)
        {
            _currentCube =
                Instantiate(cubePrefab, platform.position + Vector3.forward * 2f, Quaternion.identity);
        }

        else if (randomSpawnPoint == 3)
        {
            _currentCube =
                Instantiate(cubePrefab, platform.position + Vector3.back * 2f, Quaternion.identity);
        }
    }
    private IEnumerator CubeSpawnCoroutine()
    {
        yield return new WaitForSeconds(.65f);
        Destroy(_currentCube.gameObject, .65f);

        int newValue = Random.Range(0, 4);
        CreateCube(_currentCube, newValue);
        StartCoroutine(CubeSpawnCoroutine());
    }
}

