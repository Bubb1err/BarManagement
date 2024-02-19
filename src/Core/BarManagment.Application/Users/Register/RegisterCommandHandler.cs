using BarManagment.Application.Core.Abstractions.Authentication;
using BarManagment.Application.Core.Abstractions.Cryptography;
using BarManagment.Contracts.Authentication;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Users.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, TokenResponse>
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public RegisterCommandHandler(
            IRepository<User> usersRepository, 
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }
        public async Task<TokenResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_usersRepository.GetAll(user => user.Email == request.Email).Any())
            {
                throw new ExecutingException($"User with email {request.Email} already exists.", System.Net.HttpStatusCode.BadRequest);
            }

            string passwordHashed = _passwordHasher.HashPassword(request.Password);

            var user = User.CreateManager(request.Name, request.Surname, request.Patronymic, request.Email, request.PhoneNumber, passwordHashed);
            await _usersRepository.AddAsync(user);
            await _usersRepository.SaveChangesAsync();


            string token = _jwtProvider.Create(user);

            return new TokenResponse(token);
        }
    }
}
