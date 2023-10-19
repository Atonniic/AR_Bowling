using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingScript : MonoBehaviour
{
    // [SerializeField] private GameObject ballObject;
    public GameObject ballObject;
    [SerializeField] private Camera arCamera;
    [SerializeField] private Slider slider;


    public void luanchBall()
    {
        //TODO: Instantiate the ball in the scnen
        //TODO: Apply impulse force on the ball object

        GameObject ballInstantiated = Instantiate(ballObject, arCamera.transform.position, arCamera.transform.rotation);
        Vector3 impulse = new Vector3(1, 0, ((slider.value + 0.5f) * 300f));
        //Vector3 impulse = new Vector3(1, 0, slider.value + 300f);
        ballInstantiated.GetComponent<Rigidbody>().AddRelativeForce(impulse);
    }

}
