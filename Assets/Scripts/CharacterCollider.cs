using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Alyx.BrunchIt{
    public class CharacterCollider : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collider){
            Debug.Log("Entered collider");
        }

    }

}
