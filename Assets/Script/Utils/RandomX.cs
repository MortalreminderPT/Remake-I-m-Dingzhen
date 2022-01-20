using UnityEngine;

namespace Script.Utils {
    public static class RandomX{
        
        
        // Start is called before the first frame update
        public static int getNextSeed(int _seed) {
            Random.InitState(_seed);
            return Random.Range(123456789,987654321);
        }
    }
}
