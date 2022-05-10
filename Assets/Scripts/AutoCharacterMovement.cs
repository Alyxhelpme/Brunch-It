using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Alyx.BrunchIt{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AutoCharacterMovement : MonoBehaviour
    {
        public float speed;
        private Animator animator;
        private NavMeshAgent agent;
        [SerializeField] Transform Lechita;

        private void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        
        // Update is called once per frame
        void Update()
        {
            float dist = Vector2.Distance(Lechita.transform.position,transform.position);
            if (dist <= 10){
                agent.SetDestination(Lechita.position);
            }
            if (transform.position.x <= -1){
                if(transform.position.y >= 1){
                    animator.SetInteger("Direction", 4);
                }else if (transform.position.y <= -1){
                    animator.SetInteger("Direction", 6);
                }
            }
        }
    }
}

