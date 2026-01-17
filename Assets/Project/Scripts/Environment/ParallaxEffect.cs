using UnityEngine;

public class ParallaxEffect : MonoBehaviour 
{
    
    private float _startingPosition;
    private float _lengthOfSprite;
    public float ParallaxAmount;

    // Camera reference
    public Camera MainCamera;

    // Getting the sprite's starting position & length
    private void Start()
    {
        _startingPosition = transform.position.x;
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Updating sprite position per second
    private void Update() 
    {
        Vector3 Position = MainCamera.transform.position;

        float Temp = Position.x * (1 - ParallaxAmount);
        float Distance = Position.x * ParallaxAmount;

        Vector3 NewPosition = new Vector3(_startingPosition + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;
    }

}
