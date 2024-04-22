﻿using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DAO
{
    internal interface IPatientDAO : IGenericDAO<Patient>
    {
        //Patient GetPatientById(int id);
        //Patient GetPatientByName(string name);
        //Patient GetPatientByPhone(string phoneNum);
        //void SavePreferredFoods(string patientId, List<DietaryEntity> foods);
        //void SaveFoodsToAvoid(string patientId, List<DietaryEntity> foods);
    }
}
