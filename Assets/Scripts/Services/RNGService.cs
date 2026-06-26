using System.Collections.Generic;
using UnityEngine;
using SlotMachine.Data;

namespace SlotMachine.Services
{
    /// <summary>
    /// Service responsible for random number generation and selecting symbols
    /// for the slot machine reels.
    /// </summary>
    public class RNGService : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField]
        [Tooltip("The full pool of available symbols that can be rolled on the reels.")]
        private List<SymbolData> availableSymbols = new List<SymbolData>();

        /// <summary>
        /// Selects and returns an array of exactly 3 random symbols from the pool.
        /// This is used to determine the final result of a 3-reel spin.
        /// </summary>
        /// <returns>An array containing exactly 3 random SymbolData configurations.</returns>
        public SymbolData[] GenerateSpinResult()
        {
            SymbolData[] result = new SymbolData[3];
            
            // Check if there are symbols available in the pool to prevent errors
            if (availableSymbols == null || availableSymbols.Count == 0)
            {
                Debug.LogWarning("[RNGService] Available symbols pool is empty! Returning empty array elements.");
                return result;
            }

            for (int i = 0; i < 3; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, availableSymbols.Count);
                result[i] = availableSymbols[randomIndex];
            }

            return result;
        }

        /// <summary>
        /// Selects and returns a single random SymbolData from the pool.
        /// This is useful for initializing the reels with random starting symbols.
        /// </summary>
        /// <returns>A random SymbolData configuration, or null if the pool is empty.</returns>
        public SymbolData GetRandomSymbol()
        {
            if (availableSymbols == null || availableSymbols.Count == 0)
            {
                Debug.LogWarning("[RNGService] Available symbols pool is empty! Returning null.");
                return null;
            }

            int randomIndex = UnityEngine.Random.Range(0, availableSymbols.Count);
            return availableSymbols[randomIndex];
        }

        /// <summary>
        /// Exposes the underlying available symbols pool to external/visual components.
        /// </summary>
        /// <returns>The list of all SymbolData configurations in the pool.</returns>
        public List<SymbolData> GetAvailableSymbols()
        {
            return availableSymbols;
        }
    }
}
