using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUpdater : MonoBehaviour {

    NavMeshData data;
    NavMeshBuildSettings buildSettings;
    List<NavMeshBuildSource> sources;
    Bounds localBounds;
    // Use this for initialization
    void Start ()
    {
        data = new NavMeshData();
        NavMesh.AddNavMeshData(data);

        buildSettings = NavMesh.GetSettingsByID(0);

        sources = new List<NavMeshBuildSource>();
        localBounds = new Bounds(transform.position, new Vector3(500.0f, 500.0f, 500.0f));

        StartCoroutine(NavMeshUpdate());
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    IEnumerator NavMeshUpdate()
    {
        while(true)
        {
            sources.Clear();

            foreach (MeshFilter mf in FindObjectsOfType<MeshFilter>())
            {

                NavMeshBuildSource source = new NavMeshBuildSource();
                source.shape = NavMeshBuildSourceShape.Mesh;
                source.area = 0;
                source.sourceObject = mf.sharedMesh;
                source.transform = mf.transform.localToWorldMatrix;

                NavMeshModifier modifier = mf.GetComponent<NavMeshModifier>();
                source.area = modifier ? modifier.area : 0;

                sources.Add(source);
            }

            yield return NavMeshBuilder.UpdateNavMeshDataAsync(data, buildSettings, sources, localBounds);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
