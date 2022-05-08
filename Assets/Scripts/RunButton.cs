using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alyx.BrunchIt{
    public class RunButton : MonoBehaviour
    {
        public void onClick(){
            SceneManager.LoadScene(0);
        }
    }

}
