using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    float minSize = 0.5f;
    float maxSize = 2.0f;

    Rigidbody2D rb;

    float minSpeed = 50;
    float maxSpeed = 150;
    float maxSpinSpeed = 10f;

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDir = Random.insideUnitCircle;
        rb.AddForce(randomDir * randomSpeed);
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);

        //Rigidbody2D.linearVelocity.magnitude. 사용해보기
    }

    // Update is called once per frame
    void Update()
    {

    }

    //장애물 터질 때
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Vector2 contactPoint = collision.GetContact(0).point;
    //    GameObject bounceEffect = Instantiate(bounceEffectPrefab, contactPoint, Quaternion.identity);

    //    // Destroy the effect after 1 second
    //    Destroy(bounceEffect, 1f);
    //}
}
