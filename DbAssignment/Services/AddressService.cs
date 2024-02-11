using DbAssignment.Entity;
using DbAssignment.Repositories;

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
        var addressEntity = _addressRepo.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        addressEntity ??= _addressRepo.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });

        return addressEntity;
    }

    public AddressEntity GetAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _addressRepo.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }

    public AddressEntity GetAddressByAddressId(int id)
    {
        var addressEntity = _addressRepo.GetOne(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAllAddresses()
    {
        var addresses = _addressRepo.GetAll();
        return addresses;
    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updatedAddressEntity = _addressRepo.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updatedAddressEntity;
    }

    public bool DeleteAddress(int id)
    {
        _addressRepo.Delete(x => x.Id == id);
        return true;
    }
}
