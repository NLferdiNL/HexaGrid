using UnityEngine;

public static class HexObjectGenerator {

    public static GameObject GenerateHexObject(Vector3 size, Material mat) {
        GameObject obj = new GameObject();

        obj.transform.localScale = size;

        MeshFilter mf = obj.AddComponent<MeshFilter>();
        mf.mesh = HexMeshGenerator.GenerateMesh(size);

        MeshRenderer mr = obj.AddComponent<MeshRenderer>();
        mr.material = mat;

        return obj;
    }
}
