using Avalonia.Controls;
using Avalonia.Interactivity;
using LoanRules; // reference F# DLL

namespace LoanApp.Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
        {
            var age = this.FindControl<TextBox>("AgeTextBox").Text;
            var income = this.FindControl<TextBox>("IncomeTextBox").Text;
            var score = this.FindControl<TextBox>("ScoreTextBox").Text;

            var amount = this.FindControl<TextBox>("AmountTextBox").Text;
            var rate = this.FindControl<TextBox>("RateTextBox").Text;
            var term = this.FindControl<TextBox>("TermTextBox").Text;

            var customer = new Customer(
                int.Parse(age), 
                double.Parse(income), 
                int.Parse(score));

            // Create a Loan record
            var loan = new Loan(
                double.Parse(amount), 
                double.Parse(rate), 
                int.Parse(term));

            var loanRequest = new LoanRequest(
                customer,
                loan
            );

            // Call the F# function to check eligibility
            // Note: The F# function is static and can be called directly
            bool eligible = Eligibility.isEligible(loanRequest);
            var result = eligible ? "Approved" : "Denied";

            this.FindControl<TextBox>("ResultTextBox").Text = result;

        }
}