using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Services;

namespace WpfApp1.ViewModels;

public class WorkOrderViewModel
{
    private ICommand _addWorkOrderCommand;
    private ICommand _getOrdersAsyncCommand;
    private ICommand _updateWorkOrderCommand;

    public WorkOrderViewModel()
    {
        WorkOrders = new ObservableCollection<WorkOrder>();

        WorkOrders.Add(new WorkOrder {Id = 1, Description = "Work Order 1", DateCreated = new DateTime(2023, 1, 1)});
        WorkOrders.Add(new WorkOrder {Id = 2, Description = "Work Order 2", DateCreated = new DateTime(2023, 1, 2)});
        WorkOrders.Add(new WorkOrder {Id = 3, Description = "Work Order 3", DateCreated = new DateTime(2023, 1, 3)});
        WorkOrders.Add(new WorkOrder {Id = 4, Description = "Work Order 4", DateCreated = new DateTime(2023, 1, 4)});
        WorkOrders.Add(new WorkOrder {Id = 5, Description = "Work Order 5", DateCreated = new DateTime(2023, 1, 5)});
    }

    public ObservableCollection<WorkOrder> WorkOrders { get; set; }

    public ICommand AddWorkOrder
    {
        get
        {
            if (_addWorkOrderCommand == null)
                _addWorkOrderCommand = new RelayCommand(
                    _ => ExecuteAddWorkOrder(),
                    _ => CanAddWorkOrder()
                );

            return _addWorkOrderCommand;
        }
    }

    public ICommand UpdateWorkOrder
    {
        get
        {
            if (_updateWorkOrderCommand == null)
                _updateWorkOrderCommand = new RelayCommand(
                    _ => ExecuteUpdateWorkOrder(),
                    _ => CanUpdateWorkOrder()
                );

            return _updateWorkOrderCommand;
        }
    }

    public ICommand GetExternalOrdersAsync
    {
        get
        {
            if (_getOrdersAsyncCommand == null)
                _getOrdersAsyncCommand = new AsyncRelayCommand(
                    async async => await ExecuteGetOrdersAsync(),
                    _ => CanGetOrdersAsync()
                );
            return _getOrdersAsyncCommand;
        }
    }

    private bool CanGetOrdersAsync()
    {
        return true;
    }

    private async Task ExecuteGetOrdersAsync()
    {
        var result = await OrderService.GetOrdersAsync();

        foreach (var item in result)
        {
            var workOrder = new WorkOrder
            {
                Id = WorkOrders.Count + 1
            };
            workOrder.Description = item.Description;

            workOrder.DateCreated = DateTime.Now;
            WorkOrders.Add(workOrder);
        }
    }

    private bool CanAddWorkOrder()
    {
        return true;
    }

    private void ExecuteAddWorkOrder()
    {
        var workOrder = new WorkOrder
        {
            Id = WorkOrders.Count + 1
        };
        workOrder.Description = $"Work Order {workOrder.Id}";

        workOrder.DateCreated = DateTime.Now;
        WorkOrders.Add(workOrder);
    }

    private bool CanUpdateWorkOrder()
    {
        return true;
    }

    private void ExecuteUpdateWorkOrder()
    {
    }
}