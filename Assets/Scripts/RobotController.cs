using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Animator robotAnimator;
    [SerializeField] private Rigidbody robotBody;

    private Joystick joystick; 

    private void OnEnable()
    {
        GameManager.instance.activePlayer = gameObject;

        joystick = FindObjectOfType<Joystick>(); //Searches the entire scene and finds the joystick component

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving the robot
        if (joystick.Direction.magnitude > 0) //pushing the joystick
        {
            robotAnimator.SetBool("Running",true);
            robotAnimator.SetBool("Idle", false);

            robotBody.AddForce(transform.forward * moveSpeed);
        }
        else
        {
            robotAnimator.SetBool("Running", false);
            robotAnimator.SetBool("Idle", true);

        }

        //rotate the robot
        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y); //calculates the target direction

        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(direction); //apply the calculated direction to the robot
    }
}
