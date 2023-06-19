using StudentsRM.Models;
using StudentsRM.Models.Results;

namespace StudentsRM.Service.Interface
{
    public interface IResultService
    {
        // public BaseResponseModel Create(AddResultViewModel request,string lecturerId);
        public BaseResponseModel Create(AddResultViewModel request);
        BaseResponseModel Update(string resultId, UpdateResultViewModel update);
        BaseResponseModel Delete(string resultId);
        ResultResponseModel CheckStudentResult();
        ResultsResponseModel GetAll();
    }
}