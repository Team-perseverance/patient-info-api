﻿using DataLogic;
using PIDataLogic.Entities;
using Models;

namespace BuisnessLogic
{
    public class Logic : ILogic
    {
        Mapper _mapper = new Mapper();
        IRepo _repo;
        public Logic( IRepo repo)
        { 
            _repo = repo;
        }

        public string AddnewPatientInfo(Patientinfo patientInfo)
        {
            return _repo.AddnewPatientInfo(patientInfo);
        }

        public IEnumerable<PatientInfo> GetallPatientinfos()
        {
           return  _repo.GetallPatientinfos();
        }

        public IEnumerable<PatientInfo> GetPatientDetailsByemail(string Email)
        {
            return _repo.GetPatientinfosbyemail(Email);
        }

        public PatientInfo GetPatientDetailsById(Guid id)
        {
            return _repo.GetPatientinfosbyId(id);
        }

        public PIDataLogic.Entities.Patientinfo updatePatientinfos(Guid Pat_id, Patientinfo patientinfo)
        {
            return _repo.updatePatientinfos(Pat_id, patientinfo);
        }
    }
}