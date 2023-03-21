using OnlineTest.Models.Interfaces;
using OnlineTest.Models;
using OnlineTest.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTest.Services.Interface;
using OnlineTest.Models.Repository;
using AutoMapper;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.DTO.Get_DTO;

namespace OnlineTest.Services.Services
{
    public class TechnologyService : ITechnologyService
    {

        #region Fields
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor        
        public TechnologyService(ITechnologyRepository technologyRepository,IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }
        
        #endregion

        #region Methods        
        public ResponseDTO GetTechnologiesDTO()
        { 
            var response = new ResponseDTO();
            try
        {
            
                var data = _mapper.Map<List<GetTechnologiesDTO>>(_technologyRepository.GetTechnologies()).ToList();
            if(data!=null)
                {
                    response.Status = 200;
                    response.Message = "technologies are successfully fetched";
                    response.Data = data;
                }
        }
            catch (Exception ex) 
            {
                response.Status = 500;
                response.Message = "technologies are not fetched internal server error";
                response.Error=ex.Message;
            }
            return response;
        }
        public ResponseDTO GetTechnologiesPaginated(int pageNumber, int pageSize)
        {
            var response=new ResponseDTO();
            try
            {
                var data=_mapper.Map<List<GetTechnologiesDTO>>(_technologyRepository.GetTechnologiesPaginated(pageNumber, pageSize)).ToList();
                if(data !=null)
                {
                    response.Status = 200;
                    response.Message = "technology is successfully fetched using gettechnologiespaginated";
                    response.Data = data;
                }
            }
            catch (Exception ex) 
            {
                response.Status= 500;
                response.Message= "technology is not fetched internal server error";
                response.Error= ex.Message;
            }
            return response;
        }
        public ResponseDTO GetTechnologyById(int id)
        {
            var response=new ResponseDTO();
            {
                
                var data = _mapper.Map<GetTechnologiesDTO>(_technologyRepository.GetTechnologyById(id));
                if (data!=null) 
                {
                    response.Status = 200;
                    response.Message ="technology is successfully fetched using gettechnologybyid";
                    response.Data = data;
                }
            }
            return response;
        }
        public ResponseDTO AddTechnologyDTO(AddTechnologyDTO technology)
        { 
            var response= new ResponseDTO();
            try
        {
            var result= _technologyRepository.AddTechnology(_mapper.Map<Technology>(technology));
                
                if (result!=null)
                {
                    response.Status = 200;
                    response.Message ="technology is successfully added";
                    response.Data = result;
                }
                
        }
            catch (Exception ex) 
            {
                response.Status=500;
                response.Message ="technology is not added internal server error";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO UpdateTechnologyDTO(UpdateTechnologyDTO technology)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(technology.Id);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology does not exist";
                    return response;
                }
                var technologyByName = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technologyByName != null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology already exists";
                    return response;
                }
                // foreign key validation (modified by)

                var updateFlag = _technologyRepository.UpdateTechnology(_mapper.Map<Technology>(technology));
                
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update technology";
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


        public ResponseDTO DeleteTechnology(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(id);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Technology does not exist";
                    return response;
                }
                technologyById.IsActive = false;
                var deleteFlag = _technologyRepository.DeleteTechnology(_mapper.Map<Technology>(technologyById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete technology";
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
