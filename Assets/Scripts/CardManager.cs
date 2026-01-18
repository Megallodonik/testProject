using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour {
    [SerializeField] private DragAndDropSlot[] _slots;
    [SerializeField] private TasksConfigScriptableObject _config;
    private List<Card> _activeCards = new List<Card>();
    private ObjectPool<Card> _cardPool;


    private void Awake() {
        _cardPool = new ObjectPool<Card>(_config.CardPrefab.GetComponent<Card>(), _config.MaxCards, transform);
        foreach (var slot in _slots){
            StartCard("test", slot.transform.position);
        }
        
    }
    public void DeleteCard(Card card) {
        _cardPool.Return(card);
        _activeCards.Remove(card);
    }

    public void StartCard(string cardName, Vector3 slotPos) {
        Hero hero = _config.Heroes.FirstOrDefault(t => t.Name == cardName);
        if (hero != null) {
            Card card = _cardPool.Get();
            card.Init(hero, slotPos, this);
            _activeCards.Add(card);
        }
    }
}
