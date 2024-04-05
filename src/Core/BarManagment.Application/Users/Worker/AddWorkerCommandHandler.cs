using BarManagment.Application.Core.Abstractions.Authentication;
using BarManagment.Application.Core.Abstractions.Cryptography;
using BarManagment.Application.Core.Abstractions.Email;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Users.Worker
{
    internal sealed class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommand>
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IEmailSender _emailSender;

        public AddWorkerCommandHandler(
            IRepository<User> usersRepository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider,
            IEmailSender emailSender)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _emailSender = emailSender;
        }

        public async Task Handle(AddWorkerCommand request, CancellationToken cancellationToken)
        {
            if (_usersRepository.GetAll(user => user.Email == request.Email).Any())
            {
                throw new ExecutingException($"User with email {request.Email} already exists.", System.Net.HttpStatusCode.BadRequest);
            }

            var admin = await _usersRepository.GetFirstOrDefaultAsync(user => user.Id == request.AdminId);

            if (admin is  null)
            {
                throw new ExecutingException($"User with id {request.AdminId} does not exist.", System.Net.HttpStatusCode.BadRequest);
            }

            string passwordHashed = _passwordHasher.HashPassword(request.Password);

            var user = User.CreateWorker(request.Name, request.Surname, request.Patronymic, request.Email, request.Phone, admin.CompanyCode, passwordHashed);
            await _usersRepository.AddAsync(user);
            await _usersRepository.SaveChangesAsync();

            await _emailSender.SendEmailAsync(user.Email, "You were added to the organization", $@"
<div>
<p>You were added to the organization with code {admin.CompanyCode}.</p>
<p>Ask your admin for you credentials to access the organization management workspace.</p>
</div>
");

        }
    }
}
