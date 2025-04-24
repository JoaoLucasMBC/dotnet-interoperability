using LoanRules;

var customer = new Customer(30, 60000, 700);
var loan = new Loan(10000, 0.2, 10);
var loanRequest = new LoanRequest(customer, loan);

Console.WriteLine(LoanRules.Eligibility.isEligible(loanRequest));