using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface ISubjectService
  {
    IResult Add(Subject subject);
    IResult Delete(Subject subject);
    IDataResult<List<Subject>> GetAll();
    IDataResult<Subject> GetById(int id);
    IDataResult<List<Subject>> GetByCategoryId(int categoryId);
    IDataResult<List<CategorySubjectDto>> GetCategorySubjects();
    IDataResult<List<CategorySubjectDto>> GetMyCategorySubjects(int userId);
  }
}
