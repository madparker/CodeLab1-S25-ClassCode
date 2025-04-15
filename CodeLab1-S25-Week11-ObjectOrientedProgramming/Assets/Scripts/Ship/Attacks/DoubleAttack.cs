using UnityEngine;

public class DoubleAttack : BaseAttack
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        Vector2 currentPosition = transform.position;

        Vector2 positionA = new Vector2(
            currentPosition.x - 0.2f,
            currentPosition.y + 1);

        Vector2 positionB = new Vector2(
            currentPosition.x + 0.2f,
            currentPosition.y + 1);
        
        SpawnBullet(positionA);
        SpawnBullet(positionB);
    }
}
