using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderInput))]
public class HexFieldGenerator : MonoBehaviour {

    List<GameObject> field;
    SliderInput si;

    [SerializeField]
    Material hexMat;

    void Start() {
        field = new List<GameObject>();
        si = GetComponent<SliderInput>();
        GenerateField();
    }

    void GenerateField() {
        for (int i = 0; i < si.height; i++) {
            float xOffset = i % 2 != 0 ? 0.45f : 0;
            float yOffset = i * 0.778f;

            for (int j = 0; j < si.width; j++) {
                GameObject hex = HexObjectGenerator.GenerateHexObject(new Vector3(1, 1, 1), hexMat);
                hex.transform.parent = transform;
                hex.transform.Rotate(new Vector3(0, 1, 0), 90);
                hex.transform.position = transform.position;
                hex.transform.position += new Vector3(xOffset + j * 0.9f, yOffset, transform.position.z);
                field.Add(hex);
            }
        }
    }

    void Update() {
        if (si.updated) {
            UpdateField();
        }
    }

    void UpdateField() {
        for (int i = 0; i < field.Count; i++) {
            Destroy(field[i]);
        }

        GenerateField();
    }
}
