using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface ICategoryService
  {
    IResult Add(Category category);
    IResult Delete(Category category);
    IDataResult<List<Category>> GetAll();
    IDataResult<Category> GetById(int id);

  }
}
