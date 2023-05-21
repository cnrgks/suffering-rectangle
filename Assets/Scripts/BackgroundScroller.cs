using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private GameManager gm;

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.position += new Vector3(-0.75f * (Time.deltaTime * gm.speedMultiplier), 0);

        if (transform.position.x <= -21.5)
        {
            transform.position = new Vector3(21.5f, transform.position.y);
        }
    }
}
