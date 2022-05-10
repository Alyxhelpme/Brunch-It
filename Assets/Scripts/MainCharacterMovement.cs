//This code was borrowed from @Cainos from the Unity Asset store on the Standard Unity Asset Store EULA Licence Agreement



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Alyx.BrunchIt
{
    public class MainCharacterMovement : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        private Rigidbody2D rb;
        private Vector2 dir;

        private bool inTrigger;
        [SerializeField] Image lives;


        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();

        }


        private void Update()
        {
            dir = Vector2.zero; //Making an empty vector for the character's movement
            if (Input.GetKey(KeyCode.Space)){
                rb.AddForce(new Vector2(0,2), ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.A)) //If moved to the left
            {
                if (Input.GetKey(KeyCode.W)){
                    dir.y = 1;
                    dir.x = -1;
                    animator.SetInteger("Direction", 4);
                }else if (Input.GetKey(KeyCode.S)){
                    dir.y = -1;
                    dir.x = -1;
                    animator.SetInteger("Direction", 6);
                }
                else{
                    dir.x = -1; //It moves on the caartesian plane -1 in x axis
                    animator.SetInteger("Direction", 3); //And we change the rotation on the direction of the character's animation
                }   

            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.W)){
                    dir.y = 1;
                    dir.x = 1;
                    animator.SetInteger("Direction", 5);
                }else if (Input.GetKey(KeyCode.S)){
                    dir.y = -1;
                    dir.x = 1;
                    animator.SetInteger("Direction", 7);
                }else{
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);  
                }

            }

            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A)){
                    dir.x = -1;
                    dir.y = 1;
                    animator.SetInteger("Direction", 4);
                }else if (Input.GetKey(KeyCode.D)){
                    dir.x = 1;
                    dir.y = 1;
                    animator.SetInteger("Direction", 5);
                }else{
                    dir.y = 1;
                    animator.SetInteger("Direction", 1);
                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A)){
                    dir.x = -1;
                    dir.y = -1;
                    animator.SetInteger("Direction", 6);
                }else if (Input.GetKey(KeyCode.D)){
                    dir.x = 1;
                    dir.y = -1;
                    animator.SetInteger("Direction", 7);
                }else{
                    dir.y = -1;
                    animator.SetInteger("Direction", 0);
                }
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            if(inTrigger){
                //Code to use when entering slippery surfaces
                Vector2 targetSpeed = (speed+10)*dir;
                Vector2 refSpeed = Vector2.zero;
                float smoothVal = .3f; //Higher = 'smoother'

                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetSpeed, ref refSpeed, smoothVal);
            }else{
                rb.velocity = speed * dir;
            }

        }
        void OnTriggerStay2D(Collider2D other){
            if (other.gameObject.tag=="mancha_1"){
                Debug.Log("Esta en la mancha");
                inTrigger=true;
            }
        }
        void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.tag=="mancha_1"){
                inTrigger=false;
            }
        }

    }
}