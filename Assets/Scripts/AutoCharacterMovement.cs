using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alyx.BrunchIt{
    public class AutoCharacterMovement : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        [SerializeField] GameObject Lechita;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        
        // Update is called once per frame
        void Update()
        {
            Vector2 distance = new Vector2 (Lechita.transform.position.x + 10, Lechita.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,distance,speed*Time.deltaTime);
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

