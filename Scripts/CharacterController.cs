using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent visitor;
    [SerializeField] private GameObject[] targets;
    private float timer;
    private float rndTime;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0;
        visitor = GetComponent<NavMeshAgent>();
        visitor.destination = targets[Random.Range(0, targets.Length)].transform.position;
        rndTime = Random.Range(1, 8);
    }

    private void Update()
    {
        if (visitor.remainingDistance > 2)
        {
            anim.SetTrigger("Run");
        }
        if (visitor.remainingDistance <= 2)
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
                visitor.destination = targets[Random.Range(0, targets.Length)].transform.position;
            }
        }
    }
}