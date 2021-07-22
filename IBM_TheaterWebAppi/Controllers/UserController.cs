using AutoMapper;
using IBM_TheaterWebAppi.Entities;
using IBM_TheaterWebAppi.ExternalsModels;
using IBM_TheaterWebAppi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Controllers
{
    [Route("user")]
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IUserUnitOfWork _userUnit;
        private readonly IMapper _mapper;

        public UserController(IUserUnitOfWork userUnit,
    IMapper mapper)
        {
            _userUnit = userUnit ?? throw new ArgumentNullException(nameof(userUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}", Name = "GetUser")]
        public IActionResult GetUser(Guid id)
        {
            var userEntity = _userUnit.Users.Get(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTO>(userEntity));
        }

        [HttpGet]
        [Route("", Name = "GetAllUsers"), Authorize]
        public IActionResult GetAllUsers()
        {
            var userEntities = _userUnit.Users.Find(u => u.Deleted == false || u.Deleted == null);
            if (userEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<UserDTO>>(userEntities));
        }

        [Route("register", Name = "Register a new account")]
        [HttpPost]
        public IActionResult Register([FromBody] UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userUnit.Users.Add(userEntity);

            _userUnit.Complete();

            _userUnit.Users.Get(userEntity.ID);

            return CreatedAtRoute("GetUser",
                new { id = userEntity.ID },
                _mapper.Map<UserDTO>(userEntity));
        }


            [Route("login")]
            [HttpPost]
            public IActionResult Login([FromBody] LoginDTO user)
            {
                if (user == null)
                {
                    return BadRequest("Invalid client request.");
                }

                var foundUser = _userUnit.Users.FindDefault(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password) && (u.Deleted == false || u.Deleted == null));

                if (foundUser != null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKey@2021"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:44314",
                        audience: "https://localhost:44314",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddHours(5),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
            }
    }
}
