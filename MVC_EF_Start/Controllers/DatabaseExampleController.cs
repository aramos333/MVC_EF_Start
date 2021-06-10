using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            // CREATE operation
            Company MyCompany = new Company();
            MyCompany.Id = "MCOB";
            MyCompany.name = "ISM";
            MyCompany.date = "ISM";
            MyCompany.isEnabled = true;
            MyCompany.type = "ISM";
            MyCompany.iexId = "ISM";

            Quote MyCompanyQuote1 = new Quote();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote1.date = "11-23-2018";
            MyCompanyQuote1.open = 46.13F;
            MyCompanyQuote1.high = 47.18F;
            MyCompanyQuote1.low = 44.67F;
            MyCompanyQuote1.close = 47.01F;
            MyCompanyQuote1.volume = 37654000;
            MyCompanyQuote1.unadjustedVolume = 37654000;
            MyCompanyQuote1.change = 1.43F;
            MyCompanyQuote1.changePercent = 0.03F;
            MyCompanyQuote1.vwap = 9.76F;
            MyCompanyQuote1.label = "Nov 23";
            MyCompanyQuote1.changeOverTime = 0.56F;
            //MyCompanyQuote1.Id = "MCOB";
            MyCompanyQuote1.Company = MyCompany;

            Quote MyCompanyQuote2 = new Quote();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote2.date = "11-25-2018";
            MyCompanyQuote2.open = 56.13F;
            MyCompanyQuote2.high = 57.18F;
            MyCompanyQuote2.low = 54.67F;
            MyCompanyQuote2.close = 57.01F;
            MyCompanyQuote2.volume = 47654000;
            MyCompanyQuote2.unadjustedVolume = 47654000;
            MyCompanyQuote2.change = 1.43F;
            MyCompanyQuote2.changePercent = 0.03F;
            MyCompanyQuote2.vwap = 9.76F;
            MyCompanyQuote2.label = "Nov 25";
            MyCompanyQuote2.changeOverTime = 0.56F;
            //MyCompanyQuote2.Id = "MCOB1";
            MyCompanyQuote2.Company = MyCompany;



            User MyUser1 = new User();
            MyUser1.Id = "U0001";
            MyUser1.firstName = "John";
            MyUser1.middleInitial = "M";
            MyUser1.lastName = "Doe";
            MyUser1.ssn = "123-45-6789";
            MyUser1.phone = "(987) 654-3210";
            MyUser1.email = "joe.m.doe@gmail.com";
            MyUser1.addressLine1 = "1001 Main St";
            MyUser1.addressLine2 = "Suite 100";
            MyUser1.city = "Tampa";
            MyUser1.state = "FL";
            MyUser1.postalCode = "33560";
            MyUser1.Accounts = new List<Account>();



            User MyUser2 = new User();
            MyUser2.Id = "U0002";
            MyUser2.firstName = "Jane";
            MyUser2.middleInitial = "A";
            MyUser2.lastName = "Doe";
            MyUser2.ssn = "123-45-6700";
            MyUser2.phone = "(987) 654-3333";
            MyUser2.email = "jane.a.doe@hotmail.com";
            MyUser2.addressLine1 = "2010 Main St";
            MyUser2.addressLine2 = "Suite 500";
            MyUser2.city = "Tampa";
            MyUser2.state = "FL";
            MyUser2.postalCode = "33562";
            MyUser2.Accounts = new List<Account>();





            Account MyAccount1 = new Account();
            MyAccount1.Id = "A000001";
            MyAccount1.Owner = MyUser1;
            MyAccount1.friendlyName = "John's IRA";
            MyUser1.Accounts.Add(MyAccount1);

            Account MyAccount2 = new Account();
            MyAccount2.Id = "A000002";
            MyAccount1.Owner = MyUser1;
            MyAccount2.friendlyName = "John's Stash";
            MyUser1.Accounts.Add(MyAccount2);


            Account MyAccount3 = new Account();
            MyAccount3.Id = "A000003";
            MyAccount3.Owner = MyUser2;
            MyAccount3.friendlyName = "Jane's Retirement";
            MyUser2.Accounts.Add(MyAccount3);


            dbContext.Companies.Add(MyCompany);
            dbContext.Quotes.Add(MyCompanyQuote1);
            dbContext.Quotes.Add(MyCompanyQuote2);
            dbContext.Users.Add(MyUser1);
            dbContext.Users.Add(MyUser2);
            dbContext.Accounts.Add(MyAccount1);
            dbContext.Accounts.Add(MyAccount2);
            dbContext.Accounts.Add(MyAccount3);
            dbContext.SaveChanges();

            // READ operation

            Company CompanyRead1 = dbContext.Companies
                                    .Where(c => c.Id == "MCOB")
                                    .First();

            Company CompanyRead2 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.Id == "MCOB")
                                    .First();

            User UserRead1 = dbContext.Users
                                  .Where(u => u.Id == "U0001")
                                  .First();

            User UserRead1A = dbContext.Users
                                  .Include(u => u.Accounts)
                                  .Where(u => u.Id == "U0001")
                                  .First();


            // UPDATE operation
            CompanyRead1.iexId = "MCOB";
            dbContext.Companies.Update(CompanyRead1);
            //dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            // DELETE operation
            //dbContext.Companies.Remove(CompanyRead1);
            //await dbContext.SaveChangesAsync();

            return View();
        }

        public ViewResult LINQOperations()
        {
            Company CompanyRead1 = dbContext.Companies
                                            .Where(c => c.Id == "MCOB")
                                            .First();

            Company CompanyRead2 = dbContext.Companies
                                            .Include(c => c.Quotes)
                                            .Where(c => c.Id == "MCOB")
                                            .First();

            Quote Quote1 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.Id == "MCOB")
                                    .FirstOrDefault()
                                    .Quotes
                                    .FirstOrDefault();

            User User1 = dbContext.Users
                                  .Where(u => u.Id == "U0001")
                                  .First();

            User Account1 = dbContext.Users
                                  .Include(u => u.Accounts)
                                  .Where(u => u.Id == "U0001")
                                  .First();

            Account Account2 = dbContext.Accounts
                                    .Where(a => a.Id == "A000003")
                                    .First();


            return View();
        }

    }
}