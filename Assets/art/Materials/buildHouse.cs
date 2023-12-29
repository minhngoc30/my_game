using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildHouse : MonoBehaviour
{
    [SerializeField] private Material material;
    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeToComplete = 3f;
        progress += Time.deltaTime / timeToComplete;
        material.SetFloat("_Progress", progress);
        progress = progress % 1f;
    }
}
