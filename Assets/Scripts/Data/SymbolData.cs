using UnityEngine;

namespace SlotMachine.Data
{
    /// <summary>
    /// Represents the configuration and metadata for a single slot machine symbol.
    /// </summary>
    [CreateAssetMenu(fileName = "NewSymbolData", menuName = "Slot Machine/Symbol Data")]
    public class SymbolData : ScriptableObject
    {
        [Header("Symbol Identity")]
        [SerializeField]
        public int symbolID;

        [SerializeField]
        public string symbolName;

        [Header("Visual Asset")]
        [SerializeField]
        public Sprite symbolSprite;

        [Header("Payout & Mechanics")]
        [SerializeField]
        public float payoutMultiplier;

        [SerializeField]
        public bool isWild;

        [SerializeField]
        public bool isBonus;
    }
}
