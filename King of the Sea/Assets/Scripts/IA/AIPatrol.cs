using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : AIBehaviour
{
    public float patroDelay = 4;

    [SerializeField]
    private Vector2 randomDirection = Vector2.zero;
    [SerializeField]
    private float currentPatrolDelay;

    private void Awake() {
        randomDirection = Random.insideUnitCircle;
    }

    public override void PerformDetection(Boat_Controller boat, AIDetector detector)
    {
        float angle = Vector2.Angle(boat.transform.right,randomDirection);
        if (currentPatrolDelay <= 0 && (angle < 2))
        {
            randomDirection = Random.insideUnitCircle;
            currentPatrolDelay = patroDelay;
        }
        else
        {
            if (currentPatrolDelay > 0)
            {
                currentPatrolDelay -= Time.deltaTime;
            }
            
        }
    }
}
