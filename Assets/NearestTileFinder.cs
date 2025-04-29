using UnityEngine;

public class NearestTileFinder
{
    private const float MaxDistance = 1.3f; // Khoảng cách tối đa để xét tile

    public Tile1 GetNearestTile1InFront()
    {
        Tile1 nearestTile = null;
        float nearestDist = Mathf.Infinity;

        foreach (Tile1 tile in Environment.Instance.Tilemap1.Tiles)
        {
            Vector3 toTile = tile.transform.position - PlayerController.Instance.transform.position;
            float dot = Vector3.Dot(PlayerController.Instance.transform.forward, toTile.normalized);

            // Chỉ xét các tile ở phía trước player (dot > 0) và trong khoảng cách 1 đơn vị
            if (dot > 0)
            {
                float dist = toTile.magnitude;
                if (dist < nearestDist && dist <= MaxDistance)
                {
                    nearestDist = dist;
                    nearestTile = tile;
                }
            }
        }

        return nearestTile;
    }

    public Tile2 GetNearestTile2InFront()
    {
        Tile2 nearestTile = null;
        float nearestDist = Mathf.Infinity;

        foreach (Tile2 tile in Environment.Instance.Tilemap2.Tiles)
        {
            Vector3 toTile = tile.transform.position - PlayerController.Instance.transform.position;
            float dot = Vector3.Dot(PlayerController.Instance.transform.forward, toTile.normalized);

            // Chỉ xét các tile ở phía trước player (dot > 0) và trong khoảng cách 2 đơn vị
            if (dot > 0)
            {
                float dist = toTile.magnitude;
                if (dist < nearestDist && dist <= MaxDistance)
                {
                    nearestDist = dist;
                    nearestTile = tile;
                }
            }
        }

        return nearestTile;
    }
}