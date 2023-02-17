using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehavior;
    [SerializeField]
    private Boat_Controller boat;
    [SerializeField]
    private AIDetector detector;

    private void Awake() {
        detector = GetComponentInChildren<AIDetector>();
        boat = GetComponentInChildren<Boat_Controller>();
    }

    private void Update() 
    {
        if (detector.TargetVisiible)
        {
            shootBehaviour.PerformDetection(boat, detector);
        }
        else
        {
            patrolBehavior.PerformDetection(boat, detector);
        }
    }
}
