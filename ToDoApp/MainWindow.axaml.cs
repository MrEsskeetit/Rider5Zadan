using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TextBoxButtonTextBlock;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
        ShowTextBlock.Text = InputTextBox.Text;
    }
}