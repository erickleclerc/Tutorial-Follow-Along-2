using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARTapToPlace : MonoBehaviour
{

    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private GameObject robotPrefab;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) //if screen has been tapped
        {
            if (GameManager.instance.activePlayer == null)
            {

                if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) //check if it touches a plane and populates a list of hitpoints
                {
                    Pose hitPose = hits[0].pose;
                    Instantiate(robotPrefab, hitPose.position, Quaternion.identity); //instantiate only one robot
                }
            }
        }
    }
}
