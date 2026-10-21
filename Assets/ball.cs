using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    Vector3 dir; //En variabel så vi kan byta riktning

    //Referenser till mål manager och paddlarna
    GoalManager goal;
    [SerializeField]
    Paddle paddle1;
    [SerializeField]
    Paddle paddle2;

    float[] allowedDirection = { -0.5f, 0.5f };
    float[] allowedDirectionX = { -1, 1 };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir = new Vector3(allowedDirectionX[Random.Range(0, allowedDirectionX.Length)], Random.Range(-1, 2), 0);
        goal = FindFirstObjectByType<GoalManager>();
        //Letar efter ett objekt med GoalManager koden 
        //Skapar sedan en referens dit.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime; //Rör bollen i riktningen dir med speed som hastighet
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "paddle") //Om bollen träffar en paddle så byter det riktning i x-led och får en slumpmässig riktning i y-led
        {
            dir.x *= -1;
            dir.y = allowedDirection [Random.Range(0,allowedDirection.Length)];
            

            if (speed < 7)
            speed *= 1.05f;
        }
        else if (collision.tag == "wall") //Om bollen träffar ett tak så studsar den tillbaka
        {
            dir.y *= -1;
        }
        else if (collision.tag == "goal")//Om bollen träffar ett mål
        {
            print("Goal");
            if (transform.position.x > 0) //kollar om bollen är på höger sida av skärmen
            {
                goal.player1Score += 1;
            }
            else //eller vänster sida av skärmen
            {
                goal.player2Score += 1;
            }
            transform.position = new Vector3(0, 0, 0); //Sätter bollen i mitten av skärmen
            
        }

    }

}