using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
	//Elementos (tipo) a spawnear
	public GameObject[] obs;
    /*
 * g-782490      
 */
    [SerializeField]
    private float timeObs = 10, //tiempor entre objetos a lanzar
    timeIncrement = 0, // incremento de velocidad
    spawnIncrement = 0,//incrementar el spawn 
    minSpawn = 0.65f,//tiempo minimo de spawn
    maxNum = 0;//numero maximo de objetos a lanzar

    [SerializeField]
    private int cacheObj = 0; //Cuantos objetos creamos previamente para tener cacheados
    private int rdmElements = 0; //Elemento a spawnear random entre los del array. 
	private int len; //Longitud del array de elementos
	private float waitingTime = 1;
	private float itemsSpawned = 0; //Elementos spawneados. 

    private ArrayList gameObjSpawn;
    private int lastSpawn = 0;

	private void Awake() {
        //Calculamos el tiempo de lanzamiento. 
		waitingTime = waitingTime + Random.Range(0, timeIncrement); 
        //Calculamos longitud del array de items que podemos lanzar
        len = obs.Length;
        if (cacheObj > 0){
            GameObject temp;
            gameObjSpawn = new ArrayList();
            for (int i = 0; i< cacheObj; i++){
                rdmElements = Random.Range(0, len);
                temp = Instantiate(obs[rdmElements], transform. position);
                temp.SetActive(false);
                gameObjSpawn.Add(temp);
            }
        }
	}

	void Update () {
		if (!GameManager._gm._paused) {
            if (waitingTime <= 0 && (maxNum == 0 || maxNum > itemsSpawned)) {
                lanza();
                if (spawnIncrement >= 0 && timeObs > minSpawn) {
                    timeObs -= spawnIncrement;
                }
				waitingTime= timeObs;
                if (timeIncrement > 0f) {
                    waitingTime += Random.Range(0, timeIncrement);
                }
                if (waitingTime < minSpawn) {
                    waitingTime = minSpawn;
                }
				itemsSpawned += 1;
			}
			else {
				waitingTime -= Time.deltaTime;
			}
		}
	}
    
	void lanza(){
        if (cacheObj==0) {
            rdmElements = Random.Range(0, len);			
		    Instantiate(obs[rdmElements], transform.position, Quaternion.identity);
        } else {
            if (lastSpawn >= gameObjSpawn.Count) {
                lastSpawn = 0;
            }
            GameObject halou = (UnityEngine.GameObject)gameObjSpawn[lastSpawn];
            halou.SetActive(true);
            lastSpawn += 1;
        }
	}
}