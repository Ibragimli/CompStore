using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.User
{

    public class SubscribeServices : ISubscribeServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscribeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> SubscribeCreate(string email)
        {
            if (email == null) throw new ItemNotFoundException("Email ünvanı boş ola bilməz");

            if (await _unitOfWork.SubscribeRepository.IsExistAsync(x => x.Email == email)) throw new ItemNameAlreadyExists($"{email} Email ünvanı ilə abunə olunub");

            bool result = Validate(email);
            if (result == true)
            {
                Subscribe subscribe = new Subscribe();
                subscribe.Email = email;
                await _unitOfWork.SubscribeRepository.InsertAsync(subscribe);
                await _unitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        private static bool Validate(string emailAddress)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            //if email is valid
            if (Regex.IsMatch(emailAddress, pattern)) return true;
            return false;
        }
    }
}
