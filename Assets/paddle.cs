using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    KeyCode up = KeyCode.W;
    [SerializeField]
    KeyCode down = KeyCode.S;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(down))
        {
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }

        transform.position =
            new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, -3.3f, 3.3f), 0);
    }
}
