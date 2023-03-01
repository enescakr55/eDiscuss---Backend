using Business.Abstract;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class SubjectManager : ISubjectService
  {
    ISubjectDal _subjectDal;
    IUserSubjectService _userSubjectService;
    ICategoryService _categoryService;
    public SubjectManager(ISubjectDal subjectDal, ICategoryService categoryService, IUserSubjectService userSubjectService)
    {
      _subjectDal = subjectDal;
      _categoryService = categoryService;
      _userSubjectService = userSubjectService;
    }
    public IResult Add(Subject subject)
    {

      _subjectDal.Add(subject);
      return new SuccessResult();
    }

    public IResult Delete(Subject subject)
    {
      _subjectDal.Delete(subject);
      return new SuccessResult();
    }

    public IDataResult<List<Subject>> GetAll()
    {
      return new SuccessDataResult<List<Subject>>(_subjectDal.GetAll());
    }

    public IDataResult<List<Subject>> GetByCategoryId(int categoryId)
    {
      return new SuccessDataResult<List<Subject>>(_subjectDal.GetAll(x => x.CategoryId == categoryId));
    }

    public IDataResult<Subject> GetById(int id)
    {
      return new SuccessDataResult<Subject>(_subjectDal.Get(x => x.SubjectId == id));
    }
    public IDataResult<List<CategorySubjectDto>> GetCategorySubjects()
    {
      var categories = _categoryService.GetAll();
      var subjects = _subjectDal.GetAll();
      List<CategorySubjectDto> csdList = new List<CategorySubjectDto>();

      foreach (var category in categories.Data)
      {
        CategorySubjectDto csd = new CategorySubjectDto();
        csd.category = category;
        csd.subject = _subjectDal.GetAll(x => x.CategoryId == category.CategoryId);
        csdList.Add(csd);
      }
      return new SuccessDataResult<List<CategorySubjectDto>>(csdList);
    }

    public IDataResult<List<CategorySubjectDto>> GetMyCategorySubjects(int userId)
    {
      List<CategorySubjectDto> csdList = new List<CategorySubjectDto>();
      var getUserSubjects = _userSubjectService.GetByUserId(userId);
      var categories = _categoryService.GetAll();
      var subjects = _subjectDal.GetAll();
      foreach(var category in categories.Data)
      {
        CategorySubjectDto csd = new CategorySubjectDto();
        csd.category = category;
        csd.subject = new List<Subject>();
        var subjectList = _subjectDal.GetAll(x => x.CategoryId == category.CategoryId);
        subjectList.ForEach(x =>
        {
          if (getUserSubjects.Data.Find(us => us.SubjectId == x.SubjectId) != null)
          {
            csd.subject.Add(x);
          }
        });
        if(csd.subject.Count > 0)
        {
          csdList.Add(csd);
        }
      }
      return new SuccessDataResult<List<CategorySubjectDto>>(csdList);
    }
  }
}
