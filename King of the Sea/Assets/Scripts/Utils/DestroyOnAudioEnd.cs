using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAudioEnd : MonoBehaviour
{
    //instanciando objeto
    AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(WaitCoroutine());
    }
    // destroi o objeto que contem o audio apos ele acabar
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(source.clip.length);
        Destroy(transform.gameObject);
    }
}
