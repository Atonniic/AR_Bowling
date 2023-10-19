using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectPlacement : MonoBehaviour
{
    [SerializeField] private ARSessionOrigin aRSessionOrigin;
    [SerializeField] private GameObject Game;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private GameObject instantiatedGame;


    // Update is called once per frame
    /*void Update()
    {
        // TODO: Detect the user touch
        if (Input.GetMouseButton(0))
        {
            bool collision = aRSessionOrigin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition,
                raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

            if (collision)
            {
                if (instantiatedCube == null)
                {
                    instantiatedCube = Instantiate(cube);
                    
                    // Delete all trackable visualizers show till now
                    foreach(var plane in aRSessionOrigin.GetComponent<ARPlaneManager>().trackables)
                        plane.gameObject.SetActive(false);

                    aRSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;

                }

                instantiatedCube.transform.position = raycastHits[0].pose.position;
            }
        }

        // TODO: Project a raycast

        // TODO: Inistantiate a virtual cube at the point where the raycast meet the detected plane
    }*/

    public void placeObject()
    {
        bool collision = aRSessionOrigin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition,
                raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

        if (collision)
        {
            if (instantiatedGame == null)
            {
                instantiatedGame = Instantiate(Game);

                // Delete all trackable visualizers show till now
                foreach (var plane in aRSessionOrigin.GetComponent<ARPlaneManager>().trackables)
                    plane.gameObject.SetActive(false);

                aRSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;

            }

            instantiatedGame.transform.position = raycastHits[0].pose.position;
        }
    }
}
