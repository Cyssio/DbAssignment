using DbAssignment.Entity;
using DbAssignment.Repositories;
using System.Diagnostics;

namespace DbAssignment.Services;

internal class CustomerService
{
    private readonly CustomerRepo _customerRepo;
    private readonly AddressService _addressService;
    private readonly RoleService _roleService;

    public CustomerService(CustomerRepo customerRepo, AddressService addressService, RoleService roleService)
    {
        _customerRepo = customerRepo;
        _addressService = addressService;
        _roleService = roleService;
    }


    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
    {
        try
        {

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        try
        {
            var customerEntity = _customerRepo.GetOne(x => x.Email == email);
            return customerEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        try
        {
            var customerEntity = _customerRepo.GetOne(x => x.Id == id);
            return customerEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<CustomerEntity> GetAllCustomers()
    {
        try
        {
            var customers = _customerRepo.GetAll();
            return customers;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        try
        {
            var updatedCustomerEntity = _customerRepo.Update(x => x.Id == customerEntity.Id, customerEntity);
            return updatedCustomerEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteCustomer(int id)
    {
        try
        {
            _customerRepo.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
