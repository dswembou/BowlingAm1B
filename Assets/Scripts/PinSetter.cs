using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    [SerializeField] Text standingDisplay;

    private bool ballEnteredBox = false;
    float balltimer = 0f;
    int pins;

    [SerializeField] GameObject pinSet;

    int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox)
        {
            balltimer += Time.deltaTime;
            if(balltimer >= 3f) //Na 3 seconde wanneer ball binnen kwam
            {
                StopCounting();
            }
        }
    }

    void StopCounting()
    {
        pins = CountStanding(); //aantal pinnen die om zijn opslaan
        standingDisplay.color = Color.green; //UI wordt groen
        GameObject.FindObjectOfType<Ball>().Reset(); //Bal moet resetten
        PinReset(); //Pinnen moeten resetten
    }

    void PinReset()
    {
        // Pinnen laten resetten
    }

    public void RaisePins()
    {
        Debug.Log("Raising pins");
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lowering pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
        GameObject newPins = Instantiate(pinSet, new Vector3(0, 80f, 1829f), Quaternion.identity);
        //newPins.transform.position += new Vector3(0, 40f, 0);
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
            print(ballEnteredBox);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponentInParent<Pin>())
        {
            print("pin left");
            Destroy(thingLeft);
        }
    }
}
