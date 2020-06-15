using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public bool inPlay = false;
    private Vector3 _ballStartPosition;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody.useGravity = false;
        _ballStartPosition = transform.position;
    }

    public void Launch(Vector3 launchVelocity)
    {
        inPlay = true;
        _rigidbody.useGravity = true;
        _rigidbody.velocity = launchVelocity;
        _audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = _ballStartPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
