using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject heroes;
    [SerializeField] GameObject zombie;

    public  GameObject  winTable;
    public GameObject restartInGameButton;


    private void Awake()
    {
        Vector3 whereToStartZombie = new Vector3(Random.Range(-3600f, 200f), 0, Random.Range(3600f, 200f));
        Vector3 whereToStartHeroes = new Vector3(Random.Range(-3600f, 200f), 0, Random.Range(3600f, 200f));
        Instantiate(heroes, whereToStartHeroes, Quaternion.identity);
        Instantiate(zombie, whereToStartZombie, Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
