using UnityEngine;

public static class HexMeshGenerator {

    public static Mesh GenerateMesh(Vector3 size) {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[7];

        vertices[0] = new Vector3(0,0,0);

        for (int i = 0; i < vertices.Length - 1; i++) {
            Vector3 point = Vector3.zero;
            point.y = size.y / 2;

            point = Quaternion.Euler(60 * i, 0, 0) * point;
            vertices[1 + i] = point;
        }

        mesh.vertices = vertices;

        int[] tri = new int[7 * 3];

        for (int i = 0; i < tri.Length / 3; i++) {
            int currentTriangle = i * 3;

            tri[currentTriangle] = 0;
            tri[currentTriangle + 1] = i;
            if (i <= 5)
                tri[currentTriangle + 2] = i + 1;
            else
                tri[currentTriangle + 2] = 1;
        }

        mesh.triangles = tri;

        Vector3[] normals = new Vector3[vertices.Length];

        for (int i = 0; i < normals.Length; i++) {
            normals[i] = Vector3.right;
        }

        mesh.normals = normals;

        Vector2[] uv = new Vector2[7];

        uv[0] = new Vector2(0.5f, 0.5f);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(0.75f, 0.75f);
        uv[3] = new Vector2(0.75f, -0.75f);
        uv[4] = new Vector2(0, -1);
        uv[5] = new Vector2(-0.75f, -0.75f);
        uv[6] = new Vector2(-0.75f, 0.75f);

        mesh.uv = uv;

        return mesh;
    }
}
