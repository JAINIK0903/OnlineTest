using OnlineTest.Models.Interfaces;
using OnlineTest.Models;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTest.Models.Repository;
using Azure.Core;
using AutoMapper;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.DTO.Get_DTO;

namespace OnlineTest.Services.Services
{
    public class TestService : ITestService
    {
        
        #region Fields
        private readonly ITestRepository _testRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor        
        public TestService(ITestRepository testRepository, IMapper mapper, ITechnologyRepository technologyRepository)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _technologyRepository = technologyRepository;
        }
        
        #endregion

        #region Methods        
        public ResponseDTO GetTestsDTO()
        {
            var response= new ResponseDTO();
            try { 
            {
                
                    var data= _mapper.Map<List<TestDTO>>(_testRepository.GetTests()).ToList();
                if(data.Count>0) 
                    {
                        response.Status = 200;
                        response.Message = "test is succesfully fetched";
                        response.Data = data;
                    }
            }
            }
            catch (Exception ex) 
            {
                response.Status = 500;
                response.Message = "test is not fetched internal server error";
            }
            return response;
        }


        public ResponseDTO AddTestDTO(AddTestDTO test)
        {
            var response=new ResponseDTO();
            try
            {
                var result= _testRepository.AddTest(_mapper.Map<Test>(test));

                if(result)
                {
                    response.Status = 200;
                    response.Message = "Test is successfully added";
                    response.Data = result;
                }
            }
            catch(Exception ex) 
            {
                response.Status=500;
                response.Message = "test is not added internal server error";
            }
            return response;
        }
        public ResponseDTO UpdateTestDTO(UpdateTestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _testRepository.UpdateTest(_mapper.Map<Test>(test));
                
                if (result)
                {
                    response.Status = 204;
                    response.Message = "test is updated successfully";
                    response.Data = result;
                }
            }
            catch(Exception ex) 
            {
                response.Status=500;
                response.Message="changes are not done internal server error ";
                response.Error=ex.Message;
            }
            return response;
        }
        public ResponseDTO GetTestsPaginated(int pageNumber, int pageSize)
        {
            var response = new ResponseDTO();
            try
            {
                
                    
                    
                    var data = _mapper.Map<List<GetTestsDTO>>(_testRepository.GetTestsPaginated(pageNumber, pageSize)).ToList();
                    response.Status = 200;
                        response.Message = "test is successfully fetched using gettestpaginated.";
                        response.Data = data;

                    
                
            }
            catch (Exception ex) 
            {
                response.Status = 500;
                response.Message = "gettestpaginated is not fetch any data internal server error";
                response.Error=ex.Message;
            }
            return response;
        }
        public ResponseDTO GetTestsById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var test = _testRepository.GetTestById(id);
                if (test == null)
                {
                    response.Status = 400;
                    response.Message = "Not Found";
                    response.Error = "test not found";
                    return response;
                }
                if (test!=null)
                {
                    var data = _mapper.Map<GetTestsDTO>(test);
                    response.Status=200;
                    response.Message ="test data is successfully fetched using gettestsbyid";
                    response.Data = test;
                }
            }
            catch(Exception ex) 
            { 
                response.Status = 500;
                response.Message = "test is not fetched using gettestsbyid internal server error";
                response.Error=ex.Message;
            }
            return response;
        }
        public ResponseDTO GetTestsByTechnologyId(int technologyId)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(technologyId);
                if (technologyById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }
                var data = _mapper.Map<List<GetTestsDTO>>(_testRepository.GetTestsByTechnologyId(technologyId).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO DeleteTest(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(id);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test does not exist";
                    return response;
                }
                testById.IsActive = false;
                var deleteFlag = _testRepository.DeleteTest(_mapper.Map<Test>(testById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete test";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        #endregion
    }

}
