using UnityEngine;

public class SpawningArrow : MonoBehaviour
{
    private float spawnTimer;
    [SerializeField] private GameObject spawningArrowPrefab;
    int dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 0.5)
        {
            Instantiate(spawningArrowPrefab, transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}
