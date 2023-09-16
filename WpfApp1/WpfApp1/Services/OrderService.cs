using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfApp1.Services;

public static class OrderService
{
    public static async Task<List<Order>> GetOrdersAsync()
    {
        var list = new List<Order>();
        list.Add(new Order {Description = "External Order 6"});
        list.Add(new Order {Description = "External Order 7"});
        list.Add(new Order {Description = "External Order 8"});
        list.Add(new Order {Description = "External Order 9"});
        list.Add(new Order {Description = "External Order 10"});

        // Simulate a delay
        await Task.Delay(500);

        return list;
    }
}