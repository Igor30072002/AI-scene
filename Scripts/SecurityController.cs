using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SecurityController : MonoBehaviour
{
    private NavMeshAgent security;
    private GameObject[] visitors;
    private float timer;
    private float rndTime;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0;
        security = GetComponent<NavMeshAgent>();
        visitors = GameObject.FindGameObjectsWithTag("Visitor");
        security.destination = visitors[Random.Range(0, visitors.Length)].transform.position;
        rndTime = Random.Range(1, 8);
    }

    private void Update()
    {
        if (security.remainingDistance > 3)
        {
            anim.SetTrigger("Run");
        }
        if (security.remainingDistance <= 3)
        {
            if (timer < rndTime)
            {
                timer += Time.deltaTime;
                anim.SetTrigger("Idle");
            }
            else if (timer >= rndTime)
            {
                timer = 0;
                rndTime = Random.Range(1, 8);
                security.destination = visitors[Random.Range(0, visitors.Length)].transform.position;
            }
        }
    }
}
