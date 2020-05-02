using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    //public GameObject[] rowSets;
    public List<GameObject> rows;

    //private GameObject audioBoard;

    //public List<GameObject> cubes;

    public static bool isLoop;

    Renderer renderer;
    Color originalColor;
    public bool activated;

    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        originalColor = renderer.material.color;
        activated = false;
        isLoop = false;
        //audioBoard = GameObject.Find("PianoBoard(Clone)");
        //rowSets = new GameObject[audioBoard.transform.childCount];

        //rows = new List<GameObject>();
        //cubes = new List<GameObject>();


        //for (int i = 0; i < rowSets.Length; i++)
        //{
        //    rowSets[i] = GameObject.Find($"PianoBoard(Clone)/RowsSet{i + 1}");

        //    for (int j = 0; j < rowSets[i].transform.childCount; j++)
        //    {
        //        rows.Add(GameObject.Find($"PianoBoard(Clone)/RowsSet{i + 1}/Row {j + 1}"));
        //    }
        //}
    }

    public void PlayAllRows()
    {
        activated = !activated;
        if (activated)
        {
            isLoop = true;
            StartCoroutine(PlaySoundCoroutine());
            renderer.material.SetColor("_Color", Color.red);
            Debug.Log("Looping");
            
        }
        else
        {
            isLoop = false;
            StopCoroutine(PlaySoundCoroutine());
            renderer.material.SetColor("_Color", originalColor);
            Debug.Log("not looping");
            
        }
    }

    IEnumerator PlaySoundCoroutine()
    {
        while (isLoop)
        {
            for (int j = 0; j < rows.Count; j++)
            {
                rows[j].GetComponent<Row>().PlayRow();
                yield return new WaitForSeconds(0.35f);
            }
        }   
    }
}

