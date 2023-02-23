using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetector : MonoBehaviour
{
    //instanciando objeto
    [Range(1, 15)]
    [SerializeField]
    private float viewRadious = 11;
    [SerializeField]
    private float detectionCheckDelay = 0.1f;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityPlayer;

    [field: SerializeField]
    public bool TargetVisiible { get; private set; }

    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisiible = false;
        }
    }

    //ativa a rotina de deteccao
    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    // verifica a cada frame se o alvo nao e nulo
    // se nao for, seta a visibilidade do alvo como true
    private void Update()
    {
        if (Target != null)
        {
            TargetVisiible = CheckTargetVisible();
            Debug.Log("vejo");
        }
    }

    //verifica se o alvo e visivel e retorna true ou false
    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadious,
        visibilityPlayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    //chama os metodos para saber se o player esta no  alcance ou nao
    private void DetectionTarget()
    {
        if (Target == null)
        {
            CheckIfPlayerInRange();
        }
        else if (Target != null)
        {
            DetectIfOutOfRange();
        }
    }

    // se tiver ele pega o transform dele
    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadious, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

    //se nao tiver, seta o alvo como nulo
    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position,
        Target.position) > viewRadious)
        {
            Target = null;
        }

    }

    //cria a corotina de deteccao
    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectionTarget();
        StartCoroutine(DetectionCoroutine());
    }

    //desenha no modo editor o alcance da deteccao
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadious);
    }
}
