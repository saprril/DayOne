// --- Generic Types ---
// This is a generic class that can work with any type 'T'.
// The 'where' clause constrains 'T' to be a class.

namespace Day4Generics
{

    public class GenericRepository<T> where T : class, IEntity
    {
        // A private list to store our generic objects.
        private readonly List<T> _items = new List<T>();

        // TODO: Complete the Add method to add an item to the repository.
        public void Add(T item)
        {
            _items.Add(item);
        }

        // TODO: Complete the GetById method to retrieve an item by its ID.
        // NOTE: This will require a cast or a check for an 'Id' property.
        // A good way to do this would be to use a predicate.
        // For simplicity, let's assume T has an 'Id' property.
        
        // public T GetById(int id)
        // {
        //     // Your code here.
        //     // You'll need to find the item with the matching ID.
        //     return _items.FirstOrDefault(p => p.Id == id);
        // }
        

        // TODO: Complete the GetAll method to return all items.
        public IEnumerable<T> GetAll()
        {
            // Your code here.
            return _items;
        }

        // --- Generic Methods ---
        // This is a generic method with its own generic type 'U'.
        // The 'where U : T' constraint means 'U' must be a subclass of 'T'.
        // This demonstrates subclassing generic methods.
        // public void PrintAll<U>() where U : T
        // {
        //     Console.WriteLine($"\n--- Printing all items of type {typeof(U).Name} ---");
        //     // TODO: Iterate through the _items list and print each item's details.
        //     foreach (var item in _items)
        //     {
        //         Console.WriteLine(item.ToString());
        //     }
        // }
        
    }
}