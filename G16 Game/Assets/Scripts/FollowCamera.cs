using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    public AstarPath GridGraph;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.Equals(null))
        {
            GridGraph.astarData.gridGraph.center = new Vector3(player.transform.position.x + offset.x, GridGraph.astarData.gridGraph.center.y,
           GridGraph.astarData.gridGraph.center.z);
            AstarPath.active.Scan();
        }

    }
}
