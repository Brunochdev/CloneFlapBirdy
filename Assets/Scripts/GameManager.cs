using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}
    // Start is called before the first frame update
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> pipePrefabs;
    public float pipeInterval = 2;
    public float pipeSpeed = 10;
    public float xVariationPipe = 30;
    public Vector2 yVariationPipe= new Vector2(5, -5);
    public int points = 0;
    [HideInInspector]
    private bool isGameOver = false;
    
    void Awake(){
        if(Instance != null && Instance != this){
            Destroy (this);
        }else{
            Instance = this;
        }
    }

    public bool IsGameActive(){
        return !isGameOver;
    }
    public bool IsGameOver() {
        return isGameOver;
    }
    
    public void EndGame(){
        isGameOver = true;
        Debug.Log("Game Over! You made: "+points+" points!");
        StartCoroutine(ReloadScene (2));
    }

    private IEnumerator ReloadScene (float restart){
        yield return new WaitForSeconds(restart);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
