﻿// Borrowed from http://www.peterprovost.org/blog/2012/04/15/visual-studio-11-fakes-part-1/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch2017
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public interface ICustomerRepository
    {
        Customer GetById(int Id);
        IEnumerable<Customer> GetAll();
        Customer SaveOrUpdate(Customer customer);
        void Delete(Customer customer);
    }

    public class CustomerViewModel
    {
        private Customer customer;
        private readonly ICustomerRepository repository;

        public CustomerViewModel(Customer customer, ICustomerRepository repository)
        {
            this.customer = customer;
            this.repository = repository;
        }

        public string Name
        {
            get { return customer.Name; }
            set
            {
                customer.Name = value;
                // do something else
            }
        }

        public void Save()
        {
            customer = repository.SaveOrUpdate(customer);
        }
    }
}
