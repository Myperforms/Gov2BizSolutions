using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodeAssessment.Application.Features.Interfaces;
using CodeAssessment.Application.Features.Models;
using CodeAssessment.Infrastructure.IRepositories;
using Microsoft.Extensions.Logging;

namespace CodeAssessment.Application.Features.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AdminUserService> _logger;
        private readonly IAdminUserRepository _adminUserRepository;
        public AdminUserService(IMapper mapper,ILogger<AdminUserService> logger, IAdminUserRepository adminUserRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _adminUserRepository = adminUserRepository;
        }

        public List<AdminUser> GetAdminUsers(string emailAddress)
        {
            return this._mapper.Map<List<AdminUser>>(this._adminUserRepository.GetAllUser(emailAddress));
        }
    }
}