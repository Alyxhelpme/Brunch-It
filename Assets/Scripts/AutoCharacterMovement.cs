using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Alyx.BrunchIt{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AutoCharacterMovement : MonoBehaviour
    {
        private Animator animator;
        public Transform target;
        NavMeshAgent nav;

        private void Start()
        {
            animator = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();
        }

        
        // Update is called once per frame
        void Update()
        {
            nav.SetDestination(target.position);
            // if (transform.position.x <= -1){
            //     if(transform.position.y >= 1){
            //         animator.SetInteger("Direction", 4);
            //     }else if (transform.position.y <= -1){
            //         animator.SetInteger("Direction", 6);
            //     }
            // }
        }
    }
}

