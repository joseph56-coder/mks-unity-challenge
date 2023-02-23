using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrolPathBehaviours : AIBehaviour
{
    //instanciando objeto
    private GameObject hand;
    public PatrolPath patrolPath;
    [Range(0.1f, 1)]
    public float arriveDistance = 1;
    public float waitTime = 0.5f;
    [SerializeField]
    private bool isWaiting = false;
    [SerializeField]
    Vector2 currentPatrolTarget = Vector2.zero;
    bool insInitialize = false;

    private int currentIndex = -1;

    private void Awake()
    {
        // verifica se o patrolpath e null
        //se for, ele procura na scena a pega ele
        if (patrolPath == null)
        {
            hand = GameObject.Find("path");
            patrolPath = hand.GetComponent<PatrolPath>();
        }
    }

    //cuida de todo o movimento de ir para um ponto para o outro durante a patrulha
    public override void PerformDetection(Boat_Controller boat, AIDetector detector)
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;

            if (!insInitialize)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(boat.transform.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                insInitialize = true;
            }
            if (Vector2.Distance(boat.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }

            Vector2 directionToGo = currentPatrolTarget - (Vector2)boat.Boat_Mover.transform.position;
            var dotProduct = Vector2.Dot(boat.Boat_Mover.transform.up, directionToGo.normalized);

            if (dotProduct < 0.98f)
            {
                var crossProduct = Vector3.Cross(boat.Boat_Mover.transform.up, directionToGo.normalized);
                int rotationResult = crossProduct.z >= 0 ? -1 : 1;
                boat.HandleMoveBody(new Vector2(rotationResult, 1));
            }
            else
            {
                boat.HandleMoveBody(Vector2.up);
            }
        }
    }

    //rotina para esperar antes de ir para o proximo ponto
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        var nexPathPoint = patrolPath.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nexPathPoint.Position;
        isWaiting = false;
    }
}
