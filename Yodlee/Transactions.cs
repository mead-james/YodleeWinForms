using System;
using System.Collections.Generic;

namespace Yodlee
{
    public class Amount
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class Description
    {
        public string original { get; set; }
        public string consumer { get; set; }
        public string simple { get; set; }
    }

    public class Address
    {
        public string address1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zip { get; set; }
    }

    public class Merchant
    {
        public string id { get; set; }
        public string source { get; set; }
        public string name { get; set; }
        public IList<string> categoryLabel { get; set; }
        public Address address { get; set; }
    }

    public class Transaction
    {
        public string CONTAINER { get; set; }
        public int id { get; set; }
        public Amount amount { get; set; }
        public RunningBalance runningBalance { get; set; }
        public string baseType { get; set; }
        public string categoryType { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public string categorySource { get; set; }
        public int highLevelCategoryId { get; set; }
        public string date { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastUpdated { get; set; }
        public string postDate { get; set; }
        public Description description { get; set; }
        public bool isManual { get; set; }
        public int sourceId { get; set; }
        public string status { get; set; }
        public int accountId { get; set; }
        public string type { get; set; }
        public string subType { get; set; }
        public Merchant merchant { get; set; }
    }

    public class Transactions
    {
        public IList<Transaction> transaction { get; set; }
    }
}
