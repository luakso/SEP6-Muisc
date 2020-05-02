using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject Table;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        Table.transform.Translate(new Vector3(0,0.1f,0));
    }

    public void MoveDown()
    {
        Table.transform.Translate(new Vector3(0, -0.1f, 0));
    }

    public void RotateIn()
    {
        Table.transform.Rotate(Vector3.left, 10.0f);
    }

    public void RotateOut()
    {
        Table.transform.Rotate(Vector3.right, 10.0f);
    }
}
