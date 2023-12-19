using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    GameObject LivesGameObject;
    TextMeshProUGUI TextLives;

    [SerializeField]
    GameObject GameOver;
    TextMeshProUGUI GameOverText;

    [SerializeField]
    float BallSpeed = 1;

    [SerializeField]
    float ÖkadBallSpeed = 0.1f;

    [SerializeField]
    int Health = 3;
    

    Rigidbody MyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        GameOverText = GameOver.GetComponent<TextMeshProUGUI>();

        TextLives = LivesGameObject.GetComponent<TextMeshProUGUI>();
        
        MyRigidBody = GetComponent<Rigidbody>();
        MyRigidBody.AddForce(new Vector3(0, -1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        string GameOverVariable = "Game Over";
        GameOverText.text = GameOverVariable;

        MyRigidBody.velocity = MyRigidBody.velocity.normalized * BallSpeed;

        if(gameObject.transform.position.y <= -6)
        {
            transform.position = new Vector3(0, 0, 2);
            MyRigidBody.velocity = (new Vector3(0, -1, 0));

            Health -= 1;

            BallSpeed = 5;
        }
        if (Health == 0)
        {
            GameOver.SetActive(true);
            Destroy(gameObject);
        }
        string LivesText = "Lives: " + Health + " Lives left";
        TextLives.text = LivesText;

    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject otherGameObject = collision.gameObject;
        Enemy hitEnemy = otherGameObject.GetComponent<Enemy>();

        if (hitEnemy!= null)
        {
            hitEnemy.TakeDamage();
        }
        if (collision.gameObject)
        {
            BallSpeed += ÖkadBallSpeed;
        }
    }
}
