using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSounds : MonoBehaviour
{
    Renderer renderer;
    Color originalColor;
    public bool activated;

    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        originalColor = renderer.material.color;
        activated = false;
    }
    public void LoopAllSounds()
    {
        activated = !activated;
        if (activated)
        {
            renderer.material.SetColor("_Color", Color.red);
            Play.isLoop = true;
        }
        else
        {
            renderer.material.SetColor("_Color", originalColor);
            Play.isLoop = false;
        }
    }
}
