using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alyx.BrunchIt{
    public class RunButton : MonoBehaviour
    {
        public int escena;
        public void onClick(){
            SceneManager.LoadScene(escena);
        }
    }

}
