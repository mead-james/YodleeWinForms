using System;
using System.Collections.Generic;

namespace Yodlee
{
    public class Balance
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Cash
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class MarginBalance
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Dataset
    {
        public string name { get; set; }
        public string additionalStatus { get; set; }
        public string updateEligibility { get; set; }
        public DateTime lastUpdated { get; set; }
        public DateTime lastUpdateAttempt { get; set; }
        public DateTime? nextUpdateScheduled { get; set; }
    }

    public class LastEmployeeContributionAmount
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class AvailableCash
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class AvailableCredit
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class LastPaymentAmount
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    // NOTE: THIS CLASS IS REFERRED TO IN TRANSACTIONS AS WELL!
    public class RunningBalance
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class TotalCashLimit
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class TotalCreditLine
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class AmountDue
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class MinimumAmountDue
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class CurrentBalance
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class AvailableBalance
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class OriginalLoanAmount
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class PrincipalBalance
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Account
    {
        public object[] date;
        public object vendor;
        public object amount;

        public string CONTAINER { get; set; }
        public int providerAccountId { get; set; }
        public string accountName { get; set; }
        public string accountStatus { get; set; }
        public string accountNumber { get; set; }
        public string aggregationSource { get; set; }
        public bool isAsset { get; set; }
        public Balance balance { get; set; }
        public int id { get; set; }
        public bool includeInNetWorth { get; set; }
        public string providerId { get; set; }
        public string providerName { get; set; }
        public bool isManual { get; set; }
        public string accountType { get; set; }
        public string displayedName { get; set; }
        public DateTime createdDate { get; set; }
        public Cash cash { get; set; }
        public DateTime lastUpdated { get; set; }
        public MarginBalance marginBalance { get; set; }
        public IList<Dataset> dataset { get; set; }
        public LastEmployeeContributionAmount lastEmployeeContributionAmount { get; set; }
        public string lastEmployeeContributionDate { get; set; }
        public string dueDate { get; set; }
        public double? cashApr { get; set; }
        public AvailableCash availableCash { get; set; }
        public AvailableCredit availableCredit { get; set; }
        public LastPaymentAmount lastPaymentAmount { get; set; }
        public string lastPaymentDate { get; set; }
        public RunningBalance runningBalance { get; set; }
        public TotalCashLimit totalCashLimit { get; set; }
        public TotalCreditLine totalCreditLine { get; set; }
        public AmountDue amountDue { get; set; }
        public MinimumAmountDue minimumAmountDue { get; set; }
        public CurrentBalance currentBalance { get; set; }
        public double? annualPercentageYield { get; set; }
        public double? interestRate { get; set; }
        public string maturityDate { get; set; }
        public AvailableBalance availableBalance { get; set; }
        public string classification { get; set; }
        public string interestRateType { get; set; }
        public OriginalLoanAmount originalLoanAmount { get; set; }
        public PrincipalBalance principalBalance { get; set; }
        public string originationDate { get; set; }
        public string frequency { get; set; }
        public double? apr { get; set; }
    }

    public class Accounts
    {
        public IList<Account> account { get; set; }
    }



}

