using Microsoft.EntityFrameworkCore;
using MyFundi.Domain;
using MyFundi.Services.EmailServices.Interfaces;
using MyFundi.UnitOfWork.Concretes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyFundi.ServiceEndPoint.GeneralSevices
{
    public class ServicesEndPoint
    {
        MyFundiUnitOfWork _myFundiUnitOfWork;
        IMailService _emailServices;
        public ServicesEndPoint(MyFundiUnitOfWork unitOfWork, IMailService emailServices)
        {
            _myFundiUnitOfWork = unitOfWork;
            _emailServices = emailServices;
        }
        public async Task<Location[]> GetAllLocations()
        {
            var location = _myFundiUnitOfWork._locationRepository.GetAll().ToArray();
            return await Task.FromResult(location);
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            try
            {
                var actComUnit = _myFundiUnitOfWork._companyRepository.GetById(companyId);
                if (actComUnit == null)
                {
                    return null;
                }
                return await Task.FromResult(actComUnit);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> PostCreateAddress(Address address)
        {
            try
            {
                var result = _myFundiUnitOfWork._addressRepository.Insert(address);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> PostCreateLocation(Location location)
        {
            try
            {
                var result = _myFundiUnitOfWork._locationRepository.Insert(location);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            try
            {
                var result = _myFundiUnitOfWork._addressRepository.Update(address);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Address> SelectAddress(Address address)
        {
            try
            {
                var actAddress = _myFundiUnitOfWork._addressRepository.GetById(address.AddressId);
                if (actAddress == null)
                {
                    return null;
                }
                return await Task.FromResult(actAddress);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Location> SelectLocation(Location location)
        {
            try
            {
                var actlocation = _myFundiUnitOfWork._locationRepository.GetById(location.LocationId);
                if (actlocation == null)
                {
                    return null;
                }
                return await Task.FromResult(actlocation);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAddress(Address address)
        {
            try
            {
                var actAddress = _myFundiUnitOfWork._addressRepository.GetById(address.AddressId);
                if (actAddress == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _myFundiUnitOfWork._addressRepository.Delete(actAddress);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Address[]> GetAllAddresses()
        {
            return await Task.FromResult(_myFundiUnitOfWork._addressRepository.GetAll().ToArray());

        }
        public async Task<bool> DeleteLocation(Location location)
        {
            try
            {
                var actlocation = _myFundiUnitOfWork._locationRepository.GetById(location.LocationId);
                if (actlocation == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _myFundiUnitOfWork._locationRepository.Delete(actlocation);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
      
        public async Task<bool> UpdateLocation(Location location)
        {
            try
            {
                var result = _myFundiUnitOfWork._locationRepository.Update(location);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
   
        public async Task<bool> PostCreateCompany(Company company)
        {
            try
            {
                var result = _myFundiUnitOfWork._companyRepository.Insert(company);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCompany(Company company)
        {
            try
            {
                var result = _myFundiUnitOfWork._companyRepository.Update(company);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Company> SelectCompany(Company company)
        {
            try
            {
                var actCompany = _myFundiUnitOfWork._companyRepository.GetById(company.CompanyId);
                if (actCompany == null)
                {
                    return null;
                }
                return await Task.FromResult(actCompany);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCompany(Company company)
        {
            try
            {
                var actcompany = _myFundiUnitOfWork._companyRepository.GetById(company.CompanyId);
                if (actcompany == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _myFundiUnitOfWork._companyRepository.Delete(actcompany);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Company[]> GetAllCompanies()
        {
            return await Task.FromResult(_myFundiUnitOfWork._companyRepository.GetAll()?.Include(q => q.Location).ThenInclude(q => q.Address).Select(q => q).ToArray());
        }

        public async Task<bool> CreateLocation(Location locationDefault)
        {
            var res = false;
            var location = _myFundiUnitOfWork._locationRepository.GetAll()?.FirstOrDefault(q => q.LocationName.ToLower() == locationDefault.LocationName.ToLower());
            if (location == null)
            {
                res = _myFundiUnitOfWork._locationRepository.Insert(locationDefault);
                _myFundiUnitOfWork.SaveChanges();
            }
            return await Task.FromResult(res);
        }

        public async Task<bool> CreateAddress(Address defaultAddress)
        {
            bool res = false;
            var address = _myFundiUnitOfWork._addressRepository.GetAll()?.FirstOrDefault(q => q.AddressLine1.ToLower() == defaultAddress.AddressLine1.ToLower() && q.PostCode.ToLower() == defaultAddress.PostCode.ToLower());
            if (address == null)
            {
                res = _myFundiUnitOfWork._addressRepository.Insert(defaultAddress);
                _myFundiUnitOfWork.SaveChanges();
            }
            return await Task.FromResult(res);
        }

        public async Task<bool> CreateCompany(Company companyDefault)
        {
            var res = false;
            var company = _myFundiUnitOfWork._companyRepository.GetAll()?.FirstOrDefault(q => q.CompanyName.ToLower() == companyDefault.CompanyName.ToLower());
            if (company == null)
            {
                res = _myFundiUnitOfWork._companyRepository.Insert(companyDefault);
                _myFundiUnitOfWork.SaveChanges();
            }
            return await Task.FromResult(res);
        }


        public async Task<Address> GetAddressById(int addressId)
        {
            return await Task.FromResult(_myFundiUnitOfWork._addressRepository.GetById(addressId));
        }


        public async Task<Location> GetLocationById(int locationId)
        {
            return await Task.FromResult(_myFundiUnitOfWork._locationRepository.GetById(locationId));
        }

        public User GetUserByEmailAddress(string email)
        {
            return _myFundiUnitOfWork._userRepository.GetAll()?.First(q => q.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<bool> PostLocation(Location location)
        {
            try
            {
                _myFundiUnitOfWork._addressRepository.Insert(location.Address);
                _myFundiUnitOfWork.SaveChanges();
                location.AddressId = location.Address.AddressId;
                _myFundiUnitOfWork._locationRepository.Insert(location);
                _myFundiUnitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }


    }

}
