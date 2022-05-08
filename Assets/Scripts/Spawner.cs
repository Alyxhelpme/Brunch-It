using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour {
    [SerializeField] 
    private GameObject obstaculo;
    public int obstt;

    public IEnumerator time() {
        yield return new WaitForSeconds(2);
        if(obstt>0) {
            kawaii();
            obstt-=1;
        }
    }

    void Start() {
    }

    void Update() {
        StartCoroutine(time());
    }
    void kawaii(){
        float PosX;
        float PosY;
        float PosZ = -20f;
        PosX = Random.Range(-9f, 9f); //Los limites del plano 
        PosY = Random.Range(-9f, 9f);
        var instance = Instantiate(obstaculo, new Vector3(PosX,PosY,PosZ),new Quaternion());
        instance.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1),ForceMode.Impulse); 
    }

    void borrar() {}
}
    