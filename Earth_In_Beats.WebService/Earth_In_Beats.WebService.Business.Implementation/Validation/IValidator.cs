using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Earth_In_Beats.WebService.DAL.Contracts.Models;

namespace Earth_In_Beats.WebService.Business.Implementation.Validation
{
    public interface IValidator<TEntity> where TEntity : Entity
    {
        string[] Validate(TEntity entity);
    }
}
