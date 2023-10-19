using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;

public class ARFocusCircle : MonoBehaviour
{
    int objIndex = 0; // Initialize objIndex to 0

    public GameObject[] virtual_objects;
    public GameObject[] buttons;

    public GameObject placementIndicator;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false; // Initialize placementPoseIsValid to false

    private bool placementIndicatorEnabled = true;

    bool isUIHidden = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        if (placementIndicatorEnabled == true)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
    }

    public void HideUI()
    {
        foreach (var button in buttons)
        {
            button.SetActive(!isUIHidden);
        }

        placementIndicatorEnabled = !isUIHidden;
        placementIndicator.SetActive(!isUIHidden);

        isUIHidden = !isUIHidden;
    }

    public void PlaceObject()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == buttonName)
            {
                objIndex = i;
                break; // Exit the loop once a match is found
            }
        }

        if (objIndex >= 0 && objIndex < virtual_objects.Length)
        {
            virtual_objects[objIndex].SetActive(true);
            virtual_objects[objIndex].transform.position = placementPose.position;
            virtual_objects[objIndex].transform.rotation = placementPose.rotation;
        }
    }

    private void UpdatePlacementIndicator()
    {
        placementIndicator.SetActive(placementPoseIsValid);

        foreach (var button in buttons)
        {
            button.SetActive(placementPoseIsValid);
        }
    }

    private void UpdatePlacementPose()
    {
        if (arOrigin != null)
        {
            var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            var raycastManager = arOrigin.GetComponent<ARRaycastManager>();

            if (raycastManager != null)
            {
                var hits = new List<ARRaycastHit>();
                if (raycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated))
                {
                    placementPoseIsValid = true;
                    placementPose = hits[0].pose;

                    var cameraForward = Camera.current.transform.forward;
                    var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
                    placementPose.rotation = Quaternion.LookRotation(cameraBearing);
                }
                else
                {
                    placementPoseIsValid = false;
                }
            }
            else
            {
                placementPoseIsValid = false;
            }
        }
    }

}
