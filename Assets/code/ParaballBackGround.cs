using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaballBackGround : MonoBehaviour
{
    public bool infiniteVertical;
    public bool infiniteHorizontal;

    public Vector2 parallaxEffectMultiplier;
    private Transform cameratransform;

    private Vector3 lastCameraPosision;
    private float textureUnitSizex;

    private float textureUnitSizey;

    // Start is called before the first frame update
    void Start()
    {
        cameratransform = Camera.main.transform;
        lastCameraPosision = cameratransform.position;
      //  Sprite sprite = GetComponent<SpriteRenderer>().sprite;
       // Texture2D texture = sprite.texture;

       // textureUnitSizex = texture.width / sprite.pixelsPerUnit;
       // textureUnitSizey = texture.height / sprite.pixelsPerUnit;
    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameratransform.position- lastCameraPosision;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosision = cameratransform.position;
        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameratransform.position.x - transform.position.x) >= textureUnitSizex)
            {
                float offetpositionX = (cameratransform.position.x + transform.position.x) % textureUnitSizex;
                transform.position = new Vector3(cameratransform.position.x, cameratransform.position.y + offetpositionX);
            }
        }
        if (infiniteVertical)
        {
            if (Mathf.Abs(cameratransform.position.y - transform.position.y) >= textureUnitSizex)
            {
                float offetpositiony = (cameratransform.position.y + transform.position.y) % textureUnitSizex;
                transform.position
                = new Vector3(cameratransform.position.y, cameratransform.position.y + offetpositiony);
            }
        }
        //if (cameratransform.position.x - transform.position.x >= textureUnitSizex)
        //{
        //    float offset = (cameratransform.position.x - transform.position.x) % textureUnitSizex;
        //    transform.position = new Vector3(cameratransform.position.x + offset, transform.position.y);
        //}
    }
}
