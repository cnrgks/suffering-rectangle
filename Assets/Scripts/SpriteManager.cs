using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject targetObject1;
    public GameObject targetObject2;

    void Start()
    {
        int randSprite = Random.Range(0, sprites.Length);

        Sprite randomSprite = sprites[randSprite];

        targetObject1.GetComponent<SpriteRenderer>().sprite = randomSprite;
        targetObject2.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
