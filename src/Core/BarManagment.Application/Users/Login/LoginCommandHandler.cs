using BarManagment.Application.Core.Abstractions.Authentication;
using BarManagment.Contracts.Authentication;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using BarManagment.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Users.Login
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHashChecker _passwordHashChecker;

        public LoginCommandHandler(
            IRepository<User> usersRepository, 
            IJwtProvider jwtProvider,
            IPasswordHashChecker passwordHashChecker)
        {
            _usersRepository = usersRepository;
            _jwtProvider = jwtProvider;
            _passwordHashChecker = passwordHashChecker;
        }
        public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _usersRepository.GetFirstOrDefaultAsync(user => user.Email == request.Email, 
                include: i => i.Include(user => user.Role));

            if (userExist is null)
            {
                throw new ExecutingException($"User does not exists.", System.Net.HttpStatusCode.Unauthorized);
            }

            bool isPasswordValid = userExist.VerifyPasswordHash(request.Password, _passwordHashChecker);

            if (!isPasswordValid)
            {
                throw new ExecutingException($"Incorrect password.", System.Net.HttpStatusCode.BadRequest);
            }

            var token = _jwtProvider.Create(userExist);
            return new TokenResponse(token);
        }
    }
}
