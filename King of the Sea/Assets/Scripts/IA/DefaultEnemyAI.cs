using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    //instanciando objeto
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehavior;
    [SerializeField]
    private Boat_Controller boat;
    [SerializeField]
    private AIDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        boat = GetComponentInChildren<Boat_Controller>();
    }

    //verifica se o player e visivel para ativar ou o modo ataque ou fazer patrulha
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
