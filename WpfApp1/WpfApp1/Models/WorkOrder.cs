using System;
using System.ComponentModel;

namespace WpfApp1.Model;

public class WorkOrder : INotifyPropertyChanged
{
    private DateTime dateCreated;
    private string description;
    private int id;

    public int Id
    {
        get => id;
        set
        {
            if (id != value) id = value;
        }
    }

    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged("Description");
                Console.WriteLine("Description changed");
            }
        }
    }

    public DateTime DateCreated
    {
        get => dateCreated;
        set
        {
            if (dateCreated != value) dateCreated = value;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}