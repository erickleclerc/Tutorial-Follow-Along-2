using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Transform turretHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.activePlayer != null)
        {
            player = GameManager.instance.activePlayer.transform;

            Vector3 targetDirection = player.position - transform.position;
            Vector3 direction = Vector3.RotateTowards(turretHead.forward, targetDirection, turnSpeed * Time.deltaTime,  0);

            turretHead.rotation = Quaternion.LookRotation(direction);
        }
    }
}
