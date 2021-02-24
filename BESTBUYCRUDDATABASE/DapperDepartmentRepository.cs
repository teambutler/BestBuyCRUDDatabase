﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESTBUYCRUDDATABASE
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

            public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;"); 
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }

        //Finished DapperDepartmentRepository:
        public class DapperDepartmentRepository : IDepartmentRepository
        {
            private readonly IDbConnection _connection;

            public DapperDepartmentRepository(IDbConnection connection)
            {
                _connection = connection;
            }

            public IEnumerable<Department> GetAllDepartments()
            {
                return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
            }


            public void InsertDepartment(string newDepartmentName)
            {
                _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
            }
        }

    }
}
