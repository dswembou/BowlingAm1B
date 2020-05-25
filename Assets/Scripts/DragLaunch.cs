using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball _ball;

    private Vector3 _dragStart, _dragEnd;
    private float _startTime, _endTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _ball = GetComponent<Ball>();
    }

    public void MoveStart(float xNudge)
    {
        transform.Translate(xNudge, 0f, 0f);
    }

    // Update is called once per frame
    public void DragStart()
    {
        _dragStart = Input.mousePosition;
        _startTime = Time.time;
    }

    public void DragEnd()
    {
        _dragEnd = Input.mousePosition;
        _endTime = Time.time;

        float _dragDuration = _endTime - _startTime;

        float _launchSpeedX = (_dragEnd.x - _dragStart.x) / _dragDuration;
        float _launchSpeedZ = (_dragEnd.y - _dragStart.y) / _dragDuration;
        
        Vector3 launchVelocity = new Vector3(_launchSpeedX, 0f, _launchSpeedZ);

        _ball.Launch(launchVelocity);
    }
}
