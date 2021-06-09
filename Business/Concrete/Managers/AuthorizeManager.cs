using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class AuthorizeManager : IAuthorizeService
    {
        private IPersonService _personService;
        private IEmployeeService _employeeService;
        private ILoginService _loginService;
        private ITokenHelper _tokenHelper;
        public AuthorizeManager(IPersonService personService, IEmployeeService employeeService, ILoginService loginService, ITokenHelper tokenHelper)
        {
            _personService = personService;
            _employeeService = employeeService;
            _loginService = loginService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(Person person)
        {
            var claims = _personService.GetClaims(person);
            var accessToken = _tokenHelper.CreateToken(person, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Created");
        }

        public IDataResult<EmployeeSessionDTO> Login(EmployeeLoginDTO employeeLoginDTO)
        {
            EmployeeSessionDTO employeeSession = new EmployeeSessionDTO();
            var result = UserExistsWithEmployeeId(employeeLoginDTO.EmployeeID);
            if (!result.Success)
            {
                employeeSession.Employee = result.Data;
                var passwordCheck = _loginService.GetPassword(employeeLoginDTO.EmployeeID);
                if (HashingHelper.VerifyPasswordHash(employeeLoginDTO.Password, passwordCheck.Data.PasswordHash, passwordCheck.Data.PasswordSalt))
                {
                    employeeSession.Person = _personService.GetById(result.Data.PersonId).Data;
                    return new SuccessDataResult<EmployeeSessionDTO>(employeeSession, "Login successful");
                }
                return new ErrorDataResult<EmployeeSessionDTO>(default, "Password error");
            }
            return new ErrorDataResult<EmployeeSessionDTO>(default, "User not found");
        }

        //[SecuredOperation("admin,employee.add")]
        public IDataResult<Person> Register(EmployeeRegisterDTO employeeRegisterDTO)
        {
            string message;
            byte[] passwordSalt, passwordHash;
            //We sending memory address of variables to the method with "out" keyword
            HashingHelper.CreatePasswordHash(employeeRegisterDTO.Password, out passwordHash, out passwordSalt);
            Person person = new Person()
            {
                FirstName = employeeRegisterDTO.FirstName,
                LastName = employeeRegisterDTO.LastName,
                Identity = employeeRegisterDTO.Identity,
                Phone = employeeRegisterDTO.Phone
            };
            _personService.Add(person);
            message = "person added ";
            int personId = _personService.GetByName(employeeRegisterDTO.FirstName, employeeRegisterDTO.LastName).Data.PersonID;
            Employee employee = new Employee()
            {
                PersonId = personId,
                HireDate = employeeRegisterDTO.HireDate,
                City = employeeRegisterDTO.City,
                Region = employeeRegisterDTO.Region,
                Notes = employeeRegisterDTO.Notes,
                PhotoPath = employeeRegisterDTO.PhotoPath
            };
            _employeeService.Add(employee);
            message += "employee added ";
            int employeeId = _employeeService.GetEmployeeByPerson(personId).Data.EmployeeID;
            Login login = new Login()
            {
                EmployeeId = employeeId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _loginService.Add(login);
            message += "password added";
            return new SuccessDataResult<Person>(person, message);
        }

        public IDataResult<Employee> UserExistsWithEmployeeId(int employeeId)
        {
            var employeeToCheck = _employeeService.GetEmployee(employeeId);
            if (employeeToCheck.Data != null)
            {
                return new ErrorDataResult<Employee>(employeeToCheck.Data, "User exists");
            }
            return new SuccessDataResult<Employee>(default, "User not found");
        }
        public IResult UserExistsWithPersonelId(string personelId)
        {
            if (_personService.GetByPersonelId(personelId).Data != null)
            {
                return new ErrorResult("User exists");
            }
            return new SuccessResult("User not found");
        }
    }
}
