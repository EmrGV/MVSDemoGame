using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Follow : MonoBehaviour
{

    [SerializeField] PlayerControl playercontrol;
    public NavMeshAgent enemy;
    public Transform boostobject;

    void Start()
    {
        playercontrol = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        followenemy();
    }
    public void followenemy()
    {

        enemy.SetDestination(boostobject.position);
    }
}
