/*
Esta funcion se encarga de volver a cargar el escenario una vez que
el personaje haya muerto y que se vulva a cargar el nivel en donde se 
quedo.
BOTTOM: Vuelve al juego!
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelOnceAgain : MonoBehaviour {
    public string levelToPlay;//string que indica el nivel a cargar
    //Funcion que manda a llamar al SceneManager para que le indique
    //la escena ue se cargara al presionar el boton.
    public void playingLevel(){ 
        SceneManager.LoadScene(levelToPlay);
    }
}