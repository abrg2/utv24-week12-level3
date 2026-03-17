/* Constants */

List<string> PRODUCT_CATEGORIES = new() {
    "Processor",
    "RAM",
    "Motherboard",
    "Monitor",
    "Storage",
    "Computer case",
    "Power supply",
    "Cables"
};

/* Program entry point */

main();

/* Functions */

void main()
{
    ProductList productList = new();

    string userInput = "";

    while (true)
    {
        Console.WriteLine("--- Product Entry --- enter q to exit, or leave blank to continue adding new product");

        userInput = Console.ReadLine().Trim();

        if (userInput.ToLower() == "q")
        {
            break;
        }

        Product product = new();

        while (true)
        {
            Console.WriteLine("Category options: ");

            for (int i = 0; i < PRODUCT_CATEGORIES.Count; i++)
            {
                Console.WriteLine($"  {1 + i}. {PRODUCT_CATEGORIES[i]}");
            }
            Console.WriteLine();
            Console.Write("Enter a category number: ");
            product.category = Console.ReadLine().Trim();
            uint categoryNum;
            bool isValidUint = uint.TryParse(product.category, out categoryNum);

            if (isValidUint)
            {
                if (categoryNum >= 1 && categoryNum <= PRODUCT_CATEGORIES.Count)
                {
                    int productCategoryIndex = (int)(categoryNum - 1);
                    product.category = PRODUCT_CATEGORIES[productCategoryIndex];
                    break;
                }
                else
                    Console.WriteLine($"Invalid category number. Number must match 1 <= N <= {PRODUCT_CATEGORIES.Count}");
            }
            else
                Console.WriteLine("Invalid product category. Number must be a non-negative integer.");
        }

        Console.Write("Enter product name: ");
        product.name = Console.ReadLine().Trim();

        while (true)
        {
            Console.Write("Enter price: ");
            string productPriceString = Console.ReadLine();
            bool isValidUint = uint.TryParse(productPriceString, out product.price);

            if (isValidUint)
            {
                if (product.price >= 0 && product.price <= 999999)
                    break;
                else
                    Console.WriteLine($"Invalid price. Price must match 0 <= N <= 999999");
            }
            else
                Console.WriteLine("Invalid price. Number must be a non-negative integer.");
        }

        productList.AddProduct(product);
    }

    productList.ShowProducts();

    Console.ReadKey();
}

/* Classes */

class ProductList
{
    public List<Product> productList = new();

    public void AddProduct(Product product)
    {
        productList.Add(product);
    }

    public void ShowProducts()
    {
        foreach (Product product in productList)
        {
            Console.WriteLine("Product:");
            Console.WriteLine($"  {product.category}");
            Console.WriteLine($"  {product.name}");
            Console.WriteLine($"  {product.price}");
            Console.WriteLine();
        }

        long sum = productList.Sum(p => p.price);

        Console.WriteLine("Price sum: " + sum);
    }
}

class Product
{
    public string category = "";
    public string name = "";
    public uint price = 0;
}