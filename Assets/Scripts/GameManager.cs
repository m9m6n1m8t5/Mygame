using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();
    public Enemy enemyPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        for (var i = 1; i < 5; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.circularMovementRadius = i;
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
