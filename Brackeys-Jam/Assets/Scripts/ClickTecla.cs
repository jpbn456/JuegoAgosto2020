using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTecla : MonoBehaviour
{
    AudioSource source;
    public AudioClip mouseClick;
    public AudioClip[] keyClick;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.MouseClicked)
        {
            source.PlayOneShot(mouseClick);
        }
        if (InputManager.KeyPressed)
        {
            source.PlayOneShot(keyClick[Random.Range(0,keyClick.Length)]);
        }
    }
}
