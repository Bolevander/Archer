using UnityEngine;

namespace Archer
{
    internal class CoinDropper
    {
        public void DropACoin(Enemy enemy)
        {
            Coin coinPrefab = Resources.Load<Coin>(AssetsPath.Path[Assets.Coin]);
            for (int i = 0; i < enemy.Price; i++)
            {
                float newX = enemy.transform.position.x + Mathf.RoundToInt(i / 3);
                float newY = enemy.transform.position.y + i % 3;
                GameObject.Instantiate(coinPrefab, new Vector3(newX, newY, enemy.transform.position.z), Quaternion.identity);
            }
        }
    }
}
