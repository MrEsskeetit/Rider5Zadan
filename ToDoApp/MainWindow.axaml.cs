using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.Linq;

namespace TextBoxButtonTextBlock;

public partial class MainWindow : Window
{
    private ObservableCollection<ToDoTask> tasks = new ObservableCollection<ToDoTask>();

    public MainWindow()
    {
        InitializeComponent();
        TaskListBox.ItemsSource = tasks; 
        FilterComboBox.SelectedIndex = 0; 
    }

    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(InputTextBox.Text))
        {
            tasks.Add(new ToDoTask { Description = InputTextBox.Text, IsCompleted = false });
            InputTextBox.Text = string.Empty;
        }
    }

    private void FilterComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (FilterComboBox.SelectedItem is ComboBoxItem selectedFilter)
        {
            string filterText = selectedFilter.Content.ToString();
            TaskListBox.ItemsSource = filterText switch
            {
                "Wszystkie" => tasks,
                "Zrobione" => new ObservableCollection<ToDoTask>(tasks.Where(t => t.IsCompleted)),
                "Do zrobienia" => new ObservableCollection<ToDoTask>(tasks.Where(t => !t.IsCompleted)),
                _ => tasks,
            };
        }
    }

    private void TaskListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (TaskListBox.SelectedItem is ToDoTask selectedTask)
        {
            selectedTask.IsCompleted = !selectedTask.IsCompleted;
            TaskListBox.ItemsSource = tasks;
        }
    }
}

public class ToDoTask
{
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public override string ToString() => $"{Description} {(IsCompleted ? "[Zrobione]" : "[Do zrobienia]")}";
}
