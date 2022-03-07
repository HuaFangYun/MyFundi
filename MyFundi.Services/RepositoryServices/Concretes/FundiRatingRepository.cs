using MyFundi.Domain;
using MyFundi.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFundi.Services.RepositoryServices.Concretes
{
    public class FundiRatingRepository : AbstractRepository<FundiRating>
    {
        public override bool Delete(FundiRating toDelete)
        {
            try
            {
                toDelete = MyFundiDBContext.FundiRatings.SingleOrDefault(p => p.FundiRatingId == toDelete.FundiRatingId);
                MyFundiDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override FundiRating GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override FundiRating GetById(int id)
        {
            return MyFundiDBContext.FundiRatings.SingleOrDefault(p => p.FundiRatingId == id);
        }

        public override bool Update(FundiRating toUpdate)
        {
            try
            {
                var cert = GetById(toUpdate.FundiRatingId);
                cert.FundiRatingDescription = toUpdate.FundiRatingDescription;
                cert.FundiRatingSummary = toUpdate.FundiRatingSummary;
                cert.DateUpdated = toUpdate.DateUpdated;
                cert.Rating = toUpdate.Rating;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}