using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Vector3 launchVelocity;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody.useGravity = false;
        launchVelocity = new Vector3(0,0,200f); //tijdelijke snelheid dat de bal wordt gegooid
        //Launch(launchVelocity);
    }

    public void Launch(Vector3 launchVelocity)
    {
        _rigidbody.useGravity = true;
        _rigidbody.velocity = launchVelocity;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
