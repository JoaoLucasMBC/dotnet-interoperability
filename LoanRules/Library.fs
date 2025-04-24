namespace LoanRules

type Customer = {
    Age: int
    Income: float
    CreditScore: int
}

type Loan = {
    Amount: float
    InterestRate: float
    TermMonths: int
}

type LoanRequest = {
    Customer: Customer
    Loan: Loan
}

module Say =
    let hello name =
        "Hello " + name


module Eligibility =
    let isEligible loan =
        loan.Customer.Age >= 18 &&
        loan.Customer.Income >= 2.0 * loan.Loan.Amount &&
        loan.Customer.CreditScore > 649