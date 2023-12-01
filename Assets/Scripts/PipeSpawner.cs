using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;

        if(gameManager.IsGameOver()){
            return;
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0){
            cooldown = GameManager.Instance.pipeInterval;

            int prefabIndex = Random.Range(0, gameManager.pipePrefabs.Count);
            GameObject prefab = gameManager.pipePrefabs[prefabIndex];
            float x =  gameManager.xVariationPipe;
            float y =  Random.Range(gameManager.yVariationPipe.x, gameManager.yVariationPipe.y);
            float z = -5;
            Vector3 position = new Vector3(x ,y, z);
            Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
}
