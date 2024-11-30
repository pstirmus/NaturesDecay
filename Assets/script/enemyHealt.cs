using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealt : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField]float newFloatValue;
    [SerializeField]KeyCode key;
    private void Awake()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material; // Access the material through the Renderer
        }
        else
        {
            Debug.LogError("Renderer component not found on " + gameObject.name);
        }
    }
    private void Start()
    {
        newFloatValue = material.GetFloat("_DirtAmount");
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(key))
        {

            if (newFloatValue >= 1)
            {
                newFloatValue = Mathf.Clamp(newFloatValue / 2f,0,100);
                
            }
            else
            {
                newFloatValue = 0;
            }
            material.SetFloat("_DirtAmount", newFloatValue);
        }
    }
}
