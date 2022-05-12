//This code was borrowed from @Cainos from the Unity Asset store on the Standard Unity Asset Store EULA Licence Agreement



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Alyx.BrunchIt
{
    public class MainCharacterMovement : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        private Rigidbody2D rb;
        private Vector2 dir;
        private bool inTrigger;
        public Image[] lives;
        public Sprite emptyHeart;
        public Sprite recoverHeart;
        private bool alive;



        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            alive = true;


        }


        private void Update()
        {
            checkIfAlive();
            if (!alive){
                StartCoroutine(waitTimeForGameOver());
            }
            dir = Vector2.zero; //Making an empty vector for the character's movement
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
                Vector2 targetSpeed = (speed+80)*dir;
                Vector2 refSpeed = Vector2.zero;
                float smoothVal = .3f; //Higher = 'smoother'

                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetSpeed, ref refSpeed, smoothVal);
            }else{
                rb.velocity = speed * dir;
            }

        }
        void OnTriggerEnter2D(Collider2D other){
            
            if (other.gameObject.tag=="mancha_1"){
                for(int i=0;i<lives.Length;i++){
                    if (lives[i].sprite!=emptyHeart){
                        lives[i].sprite=emptyHeart;
                        break;
                    }
                }
            }else if (other.gameObject.tag=="Cocholata"){
                //No se escribir corcholata y ya lo deje asi en el Unity que hueva
                Debug.Log("Touched Cocholata");
                for(int i=0;i<lives.Length;i++){
                    if (lives[i].sprite==emptyHeart){
                        lives[i].sprite=recoverHeart;
                        Destroy(other.gameObject);  
                        break;
                    }
                }
            }

        }
        void OnTriggerStay2D(Collider2D other){
            if (other.gameObject.tag=="mancha_1"){
                inTrigger=true;
            }
        }
        void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.tag=="mancha_1"){
                inTrigger=false;
            }
        }
        void checkIfAlive(){
            if(lives[2].sprite==emptyHeart){
                alive=false;
            }
        }

        IEnumerator waitTimeForGameOver(){
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene("GameOverMenu");
        }

    }
}