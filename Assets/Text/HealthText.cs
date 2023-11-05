using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public TextMeshProUGUI textMesh;
    public float floatSpeed = 300f;
    RectTransform rTransform;
    Vector3 floatDirection = new Vector3(0, 1, 0);
    Color startingColor;



    float timeElaped = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        rTransform = GetComponent<RectTransform>();
        startingColor = textMesh.color;
    }

    // Update is called once per frame
    void Update()
    {
        timeElaped += Time.deltaTime;

        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.b, startingColor.b, 1 - timeElaped / timeToLive);

        if (timeElaped > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
