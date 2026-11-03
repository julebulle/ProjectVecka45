using UnityEngine;

public class SpawningArrow : MonoBehaviour
{
    public float spawnTimer;
    [SerializeField] private GameObject spawningArrowPrefab;


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
