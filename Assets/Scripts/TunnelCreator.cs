using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TunnelCreator : MonoBehaviour
{
    public float spacing = 10;
    public bool autoUpdate;
    public float size = 10;
    public float length = 100;
    public int nbrVertsPer = 3; //nombre de verts

    public Vector3 center = Vector3.zero;


    private void Awake()
    {
        CreateRoadMesh();
    }

    void CreateRoadMesh()
    {
        int nbrVertLength = (int) (length / spacing);
        Vector3[] verts = new Vector3[nbrVertLength * nbrVertsPer];
        Vector2[] uvs = new Vector2[verts.Length];
        Vector3[] normals = new Vector3[verts.Length];
        int numTris = nbrVertsPer * 2 * (nbrVertLength - 1);
        int[] tris = new int[numTris * 3];

        int vertIndex = 0;
        int triIndex = 0;

        // Vertices for the top of the road are layed out:
        // 0  1
        // 8  9
        // and so on... So the triangle map 0,8,1 for example, defines a triangle from top left to bottom left to bottom right.
        //int[] triangleMap = {0, 8, 1, 1, 8, 9};
        //int[] sidesTriangleMap = {4, 6, 14, 12, 4, 14, 5, 15, 7, 13, 15, 5};

        float vertAngle = 360f / nbrVertsPer;
        for (int i = 0; i < nbrVertLength; i++)
        {
            float zPos = i * spacing;
            for (int j = 0; j < nbrVertsPer; j++)
            {
                Vector3 vertPos = Quaternion.Euler(0, 0, j * -vertAngle) * Vector3.up + Vector3.forward * zPos;
                verts[vertIndex + j] = vertPos * size + center;

                var perVertPercentage = (float) j / nbrVertsPer;
                var perUV = 1 - Mathf.Abs(1 - 2 * perVertPercentage); //0 -> 1 -> -1
                uvs[vertIndex + j] = new Vector2(perUV, (float) i / (nbrVertLength - 1));
                normals[vertIndex + j] = Quaternion.Euler(0, 0, j * -vertAngle) * -Vector3.up;
            }


            // Set triangle indices
            if (i < nbrVertLength - 1)
            {
                for (int j = 0; j < nbrVertsPer; j++)
                {
                    var currentTriIndex = triIndex + 6 * j;
                    tris[currentTriIndex + 0] = vertIndex + j;
                    tris[currentTriIndex + 1] = j != nbrVertsPer - 1 ? vertIndex + j + nbrVertsPer + 1 : vertIndex + j + 1;
                    tris[currentTriIndex + 2] = vertIndex + j + nbrVertsPer;

                    tris[currentTriIndex + 3] = vertIndex + j;
                    tris[currentTriIndex + 4] = vertIndex + (j + 1) % nbrVertsPer;
                    tris[currentTriIndex + 5] = j != nbrVertsPer - 1 ? vertIndex + j + nbrVertsPer + 1 : vertIndex + j + 1;
                }
            }

            vertIndex += nbrVertsPer;
            triIndex += 6 * nbrVertsPer;
        }


        var mesh = new Mesh {vertices = verts, uv = uvs, normals = normals, subMeshCount = 3, triangles = tris};

        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = mesh;
    }
}

/*
[RequireComponent(typeof(PathCreator))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TunnelCreator : MonoBehaviour
{
    [Range(.05f, 1.5f)] public float spacing = 1;
    public float roadWidth = 1;
    public bool autoUpdate;
    public float tiling = 1;
    public int cylinderQuality = 10; //nombre de verts

    public void UpdateRoad()
    {
        Path path = GetComponent<PathCreator>().path;
        Vector2[] points = path.CalculateEvenlySpacedPoints(spacing);
        GetComponent<MeshFilter>().mesh = CreateRoadMesh(points, path.IsClosed);

        int textureRepeat = Mathf.RoundToInt(tiling * points.Length * spacing * .05f);
        GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(1, textureRepeat);
    }

    Mesh CreateRoadMesh(Vector2[] points, bool isClosed)
    {
        Vector3[] verts = new Vector3[points.Length * cylinderQuality];
        Vector2[] uvs = new Vector2[verts.Length];
        int numTris = cylinderQuality * 2 * (points.Length - 1) + ((isClosed) ? 2 : 0);
        int[] tris = new int[numTris * 3];
        int vertIndex = 0;
        int triIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            Vector2 forward = Vector2.zero;
            if (i < points.Length - 1 || isClosed)
            {
                forward += points[(i + 1) % points.Length] - points[i];
            }

            if (i > 0 || isClosed)
            {
                forward += points[i] - points[(i - 1 + points.Length) % points.Length];
            }

            forward.Normalize();
            Vector2 left = new Vector2(-forward.y, forward.x);


            for (int j = 0; j < cylinderQuality; j++)
            {
                Vector2 dir = left * 
                verts[vertIndex + j] = points[i] + left * roadWidth * .5f;
                //verts[vertIndex + 1] = points[i] - left * roadWidth * .5f;
            }


            float completionPercent = i / (float) (points.Length - 1);
            float v = 1 - Mathf.Abs(2 * completionPercent - 1);
            uvs[vertIndex] = new Vector2(0, v);
            uvs[vertIndex + 1] = new Vector2(1, v);

            if (i < points.Length - 1 || isClosed)
            {
                tris[triIndex] = vertIndex;
                tris[triIndex + 1] = (vertIndex + 2) % verts.Length;
                tris[triIndex + 2] = vertIndex + 1;

                tris[triIndex + 3] = vertIndex + 1;
                tris[triIndex + 4] = (vertIndex + 2) % verts.Length;
                tris[triIndex + 5] = (vertIndex + 3) % verts.Length;
            }

            vertIndex += 2;
            triIndex += 6;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.uv = uvs;

        return mesh;
    }
}*/