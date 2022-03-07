using MyFundi.Domain;
using MyFundi.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFundi.Services.RepositoryServices.Concretes
{
    public class FundiProfileFundiRatingRepository : AbstractRepository<FundiProfileFundiRating>
    {
        public override bool Delete(FundiProfileFundiRating toDelete)
        {
            try
            {
                toDelete = MyFundiDBContext.FundiProfileFundiRatings.SingleOrDefault(p => p.FundiProfileFundiRatingId == toDelete.FundiProfileFundiRatingId);
                MyFundiDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override FundiProfileFundiRating GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override FundiProfileFundiRating GetById(int id)
        {
            return MyFundiDBContext.FundiProfileFundiRatings.SingleOrDefault(p => p.FundiProfileFundiRatingId == id);
        }

        public override bool Update(FundiProfileFundiRating toUpdate)
        {
            try
            {
                var cert = GetById(toUpdate.FundiProfileFundiRatingId);
                cert.FundiProfileiId = toUpdate.FundiProfileiId;
                cert.FundiRatingId = toUpdate.FundiRatingId;
                cert.DateUpdated = toUpdate.DateUpdated;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}