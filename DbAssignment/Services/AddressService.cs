using DbAssignment.Entity;
using DbAssignment.Repositories;
using System.Diagnostics;

namespace DbAssignment.Services;

internal class AddressService
{
    private readonly AddressRepo _addressRepo;

    public AddressService(AddressRepo addressRepo)
    {
        _addressRepo = addressRepo;
    }


    public AddressEntity CreateAddress(string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressRepo.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            addressEntity ??= _addressRepo.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });

            return addressEntity;
        } 
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public AddressEntity GetAddress(string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressRepo.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return addressEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public AddressEntity GetAddressByAddressId(int id)
    {
        try
        {
            var addressEntity = _addressRepo.GetOne(x => x.Id == id);
            return addressEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<AddressEntity> GetAllAddresses()
    {
        try
        {
            var addresses = _addressRepo.GetAll();
            return addresses;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        try
        {
            var updatedAddressEntity = _addressRepo.Update(x => x.Id == addressEntity.Id, addressEntity);
            return updatedAddressEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteAddress(int id)
    {
        try
        {
            _addressRepo.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
