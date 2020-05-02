using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject audioBoardPrefab;
    [SerializeField]
    private GameObject guitarBoardPrefab;


    void Start()
    {
        Instantiate(audioBoardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(guitarBoardPrefab, new Vector3(2, 0, 0), Quaternion.identity);

    }
}
