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
        private Vector2 oldPosition;
        private bool WaffleIn;
        private bool TocinettoIn;

        private void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            oldPosition = transform.position;
            WaffleIn = false;
            TocinettoIn = false;
        }

        
        // Update is called once per frame
        void Update()
        {
            agent.isStopped = false;
            float dist = Vector2.Distance(Lechita.transform.position,transform.position);
            if (dist <= 10){
                agent.SetDestination(Lechita.position);
            }
            if (dist < 3){
                agent.isStopped = true;
            }

            if (oldPosition.x > transform.position.x){ //if old position is bigger than the now x axis position then its walking to the left
                if (oldPosition.y < transform.position.y){ //and if old position in y axis is smaller than the now y axis position then its going up too
                    animator.SetInteger("Direction", 4);
                }else if (oldPosition.y > transform.position.y){
                    animator.SetInteger("Direction", 6);
                }else{
                    animator.SetInteger("Direction", 3);
                }
            }else if (oldPosition.x < transform.position.x){ //if old position is smaller then its going to the right
                if (oldPosition.y < transform.position.y){
                    animator.SetInteger("Direction", 5);
                }else if (oldPosition.y > transform.position.y){
                    animator.SetInteger("Direction", 7);
                }else{
                    animator.SetInteger("Direction", 2);
                }
            }else if (oldPosition.y < transform.position.y){
                if (oldPosition.x > transform.position.x){
                    animator.SetInteger("Direction", 4);
                }else if (oldPosition.x < transform.position.x){
                    animator.SetInteger("Direction", 5);
                }else{
                    animator.SetInteger("Direction", 1);
                }
            }else if (oldPosition.y > transform.position.y){
                if (oldPosition.x > transform.position.x){
                    animator.SetInteger("Direction", 6);
                }else if (oldPosition.x < transform.position.x){
                    animator.SetInteger("Direction", 7);
                }else{
                    animator.SetInteger("Direction", 0);
                }
            }
            animator.SetBool("IsMoving", transform.position.magnitude > 0);
            oldPosition = transform.position;
            
        }
        void OnTriggerStay2D(Collider2D other){
            if (other.gameObject.tag == "Finish"){
                if (transform.tag == "Waffle"){
                    WaffleIn = true;                    
                }else if(transform.tag == "Tocinetto"){
                    TocinettoIn = true;
                }
            }
        }
        void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.tag == "Finish"){
                if (transform.tag == "Waffle"){
                    WaffleIn = false;                    
                }else if(transform.tag == "Tocinetto"){
                    TocinettoIn = false;
                }
            }
        }
        public bool WaffleValue(){
            return WaffleIn;
        }
        public bool TocinettoValue(){
            return TocinettoIn;
        }
    }
}

