using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alyx.BrunchIt{
    [RequireComponent(typeof(CircleCollider2D))]
    public class WiningYall : MonoBehaviour{
        public AutoCharacterMovement Waffle;
        public AutoCharacterMovement Tocinetto;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update(){
      bool waffle = Waffle.WaffleValue();
      bool tocinetto = Tocinetto.TocinettoValue();
      if ((waffle) && (tocinetto)){
          SceneManager.LoadScene("WinScene");
      } 
    }
    }

}

