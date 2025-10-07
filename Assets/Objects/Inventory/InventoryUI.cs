using UnityEngine;
using UnityEngine.UIElements;

namespace Objects.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        private Button addButton;
        private ScrollView inventoryContainer;

        private string[] possibleItems = { "Sword", "Apple", "Shield", "Potion", "Gem", "Book" };
        private int itemCount = 0;

        private void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            addButton = root.Q<Button>("add-button");
            inventoryContainer = root.Q<ScrollView>("inventory-container");

            addButton.clicked += AddRandomItem;
        }

        private void AddRandomItem()
        {
            string itemName = possibleItems[Random.Range(0, possibleItems.Length)] + $" #{++itemCount}";

            var itemButton = new Button();
            itemButton.text = itemName;
            itemButton.style.unityTextAlign = TextAnchor.MiddleLeft;

            // 💡 Bonus - the ability to delete an element
            itemButton.clicked += () => { inventoryContainer.Remove(itemButton); };

            inventoryContainer.Add(itemButton);
        }
    }
}