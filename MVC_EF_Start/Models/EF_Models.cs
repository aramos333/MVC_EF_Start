using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
    public class Company
    {
        
        public string Id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public bool isEnabled { get; set; }
        public string type { get; set; }
        public string iexId { get; set; }
        public List<Quote> Quotes { get; set; }
        public Account Account { get; set; }
       

    }

    public class Quote
    {
        public int Id { get; set; }
        public string date { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }
        public int unadjustedVolume { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public float vwap { get; set; }
        public string label { get; set; }
        public float changeOverTime { get; set; }
        public Company Company { get; set; }
    }

    public class ChartRoot
    {
        public Quote[] chart { get; set; }
    }


    public class User
    {
       
        public string Id { get; set; }
        public string firstName { get; set; }
        public string middleInitial { get; set; }
        public string lastName { get; set; }
        public string ssn { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public List<Account> Accounts { get; set; }
    }


    public class Account
    {
       
        public string Id { get; set; }
        public User Owner { get; set; }
        public string friendlyName { get; set; }
        public List<Company> Companies { get; set; }
    }
}