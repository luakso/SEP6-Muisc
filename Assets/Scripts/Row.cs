using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Audio[] cubes;

    public void PlayRow()
    {
        foreach (Audio c in cubes)
        {
            if (c.activated)
            {
                c.PlayWithoutDeactivating();
            }
        }
    }
}
