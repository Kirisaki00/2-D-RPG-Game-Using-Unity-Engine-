using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxMultiplier = 0.5f;
    [SerializeField] private float edgeOffset = 0.1f; // tiny buffer to avoid flicker

    private float imageFullWidth;
    private float imageHalfWidth;

    public void CalculateImageWidth()
    {
        SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
        imageFullWidth = sr.bounds.size.x;
        imageHalfWidth = imageFullWidth / 2f;
    }

    public void Move(float distanceToMove)
    {
        background.position += Vector3.right * (distanceToMove * parallaxMultiplier);
    }

    public void LoopBackground(float cameraLeftEdge, float cameraRightEdge)
    {
        float rightEdge = background.position.x + imageHalfWidth - edgeOffset;
        float leftEdge = background.position.x - imageHalfWidth + edgeOffset;

        if (rightEdge < cameraLeftEdge)
            background.position += Vector3.right * imageFullWidth;
        else if (leftEdge > cameraRightEdge)
            background.position += Vector3.right * -imageFullWidth;
    }
}
