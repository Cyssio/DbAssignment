using DbAssignment.Dtos;
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


    public AddressEntity CreateAddress(CreateAddressDto _createAddress)
    {
        try
        {
            var addressEntity = _addressRepo.GetOne(x => x.StreetName == _createAddress.StreetName && x.PostalCode == _createAddress.PostalCode && x.City == _createAddress.City);
            addressEntity ??= _addressRepo.Create(new AddressEntity { StreetName = _createAddress.StreetName, PostalCode = _createAddress.PostalCode, City = _createAddress.City });

            return addressEntity;
        } 
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public AddressEntity GetAddress(CreateAddressDto _getAddress)
    {
        try
        {
            var addressEntity = _addressRepo.GetOne(x => x.StreetName == _getAddress.StreetName && x.PostalCode == _getAddress.PostalCode && x.City == _getAddress.City);
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
