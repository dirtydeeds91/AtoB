using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float xSize = 19f;
    [SerializeField]
    private List<ParallaxComponent> backgroundPrefabs;

    private List<ParallaxComponent> spawnedBackgrounds;
    private List<ParallaxComponent> spawnedBuildings;
    private List<ParallaxComponent> spawnedFarBuildings;

    public StopMovement stopMovement;

    private void OnEnable()
    {
        this.spawnedBackgrounds = new List<ParallaxComponent>();
        this.spawnedBuildings = new List<ParallaxComponent>();
        this.spawnedFarBuildings = new List<ParallaxComponent>();

        ParallaxComponent background = Instantiate(this.backgroundPrefabs[0]);
        background.transform.SetParent(this.transform);
        this.spawnedBackgrounds.Add(background);
        stopMovement.AddObject(background);

        ParallaxComponent building = Instantiate(this.backgroundPrefabs[1]);
        building.transform.SetParent(this.transform);
        this.spawnedBuildings.Add(building);
        stopMovement.AddObject(building);

        ParallaxComponent spawnedFarBuilding = Instantiate(this.backgroundPrefabs[2]);
        spawnedFarBuilding.transform.SetParent(this.transform);
        this.spawnedFarBuildings.Add(spawnedFarBuilding);
        stopMovement.AddObject(spawnedFarBuilding);
    }

    private void Update()
    {
        CheckStatus(this.spawnedBackgrounds, 0);
        CheckStatus(this.spawnedBuildings, 1);
        CheckStatus(this.spawnedFarBuildings, 2);
    }

    private void CheckStatus(List<ParallaxComponent> spawned, int indexToUse)
    {
        if (spawned.Count > 0)
        {
            if (spawned[spawned.Count - 1].ShouldSpawnMore)
            {
                ParallaxComponent spawnedElement = Instantiate(this.backgroundPrefabs[indexToUse]);
                spawnedElement.transform.SetParent(this.transform);
                spawnedElement.transform.position = new Vector2(this.xSize, 0f);
                spawned.Add(spawnedElement);
                stopMovement.AddObject(spawnedElement);
            }
        }

        //Check for despawn
        if (spawned.Count > 3)
        {
            ParallaxComponent toDestroy = spawned[0];
            spawned.RemoveAt(0);
            Destroy(toDestroy.gameObject);
        }
    }
}
