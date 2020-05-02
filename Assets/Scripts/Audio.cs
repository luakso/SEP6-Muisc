using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioData;
    Renderer renderer;
    Color originalColor;

    public bool activated;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        activated = false;
        renderer = GetComponentInChildren<Renderer>();
        originalColor = renderer.material.color;
    }

    public void PlayAudio()
    {
        audioData.Play();
        activated = !activated;
        if (activated)
        {
            renderer.material.SetColor("_Color", Color.red);
        }
        else
        {
            renderer.material.SetColor("_Color", originalColor);
        }
    }
    public void PlayWithoutDeactivating()
    {
        audioData.Play();
    }
}
