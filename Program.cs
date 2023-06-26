namespace CustomHashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HashTable table = new HashTable(10);
            table.Put(105, "Tom");
            table.Put(21, "Harry");
            table.Put(31, "Dinesh");
            Console.WriteLine(table.Size()); // (31, "Dinesh") -> (21, "Harry") -> null
            Console.WriteLine(table.Remove(21));
            Console.WriteLine(table.Remove(31));
            Console.WriteLine(table.Size());

        }
    }
}