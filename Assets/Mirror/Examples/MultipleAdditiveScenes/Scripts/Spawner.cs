using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mirror.Examples.MultipleAdditiveScenes
{
    public class Spawner : NetworkBehaviour
    {
        public NetworkIdentity prizePrefab;

        public override void OnStartServer()
        {
            for (int i = 0; i < 10; i++)
                SpawnPrize();
        }

        public void SpawnPrize()
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-19, 20), 1, Random.Range(-19, 20));

            GameObject newPrize = Instantiate(prizePrefab.gameObject, spawnPosition, Quaternion.identity);
            Reward reward = newPrize.gameObject.GetComponent<Reward>();
            reward.spawner = this;

            NetworkServer.Spawn(newPrize);
            SceneManager.MoveGameObjectToScene(newPrize, gameObject.scene);
        }
    }
}
