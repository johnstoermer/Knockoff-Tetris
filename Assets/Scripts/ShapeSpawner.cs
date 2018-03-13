using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {
    public Color[] colors;
    public Color[] nextColors;
    int colorIndex = 0;
    int nextColorIndex = 0;

    public GameObject[] shapes;
    public GameObject[] nextShapes;

    GameObject upNextObject = null;

    int shapeIndex = 0;
    int nextShapeIndex = 0;

    public void SpawnShape() {

        shapeIndex = nextShapeIndex;
        colorIndex = nextColorIndex;

        GameObject shape = Instantiate(shapes[shapeIndex],
            transform.position,
            Quaternion.identity);

        foreach (Transform block in shape.transform) {
            block.GetComponent<SpriteRenderer>().color = colors[colorIndex];
        }

        nextShapeIndex = Random.Range(0, 6);
        nextColorIndex = Random.Range(0, 3);

        Vector3 nextShapePos = new Vector3(-20f, 18f, 0);

        if (upNextObject != null)
            Destroy(upNextObject);

        upNextObject = Instantiate(nextShapes[nextShapeIndex],
            nextShapePos,
            Quaternion.identity);

        foreach (Transform block in upNextObject.transform) {
            block.GetComponent<SpriteRenderer>().color = colors[nextColorIndex];
        }
    }

    void Start() {
        nextShapeIndex = Random.Range(0, 6);

        SpawnShape();

    }

    void Update() {

    }
}